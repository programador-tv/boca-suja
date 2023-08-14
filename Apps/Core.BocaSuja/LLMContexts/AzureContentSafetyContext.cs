using System.Text;
using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Enums;
using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Domain.Services;
using Core.BocaSuja.Infrastructure.Repositories.Interfaces;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.LLMContext;

public class AzureContentSafetyContext : IGenericLlmContext
{
    private AzureContentSafetyCredentials _credentials;
    private IEntidadeOfensoraRepository _entidadeOfensoraRepo;
    private IIncidenciaRepository _incidenciaRepository;
    
    private const int LIMIT_UNIT = 4;
    private const int LIMIT_SUM = 4;

    public AzureContentSafetyContext(
        AzureContentSafetyCredentials credentials,
        IEntidadeOfensoraRepository entidadeOfensoraRepo,
        IIncidenciaRepository incidenciaRepository
    )
    {
        _credentials = credentials;
        _entidadeOfensoraRepo = entidadeOfensoraRepo;
        _incidenciaRepository = incidenciaRepository;
    }

    private bool ViolateUnitLimit(ContentSafetyResult result)
    {
        return result.HateResult.Severity >= LIMIT_UNIT
            || result.SelfHarmResult.Severity >= LIMIT_UNIT
            || result.SexualResult.Severity >= LIMIT_UNIT
            || result.ViolenceResult.Severity >= LIMIT_UNIT;
    }

    private bool ViolateSumLimit(ContentSafetyResult result)
    {
        return result.HateResult.Severity
                + result.SelfHarmResult.Severity
                + result.SexualResult.Severity
                + result.ViolenceResult.Severity
            >= LIMIT_SUM;
    }


    public async Task<bool> Validate(
        string Id, 
        string Text
        )
    {
        var result = await AzureContentSafetyService.CallAPI(
            Text,
            _credentials.GetURL(),
            _credentials.GetSubscriptionKey(),
            _credentials.GetVersion()
        );

        var entidadeOfensora = await _entidadeOfensoraRepo.Select(Id);
        
        if (entidadeOfensora is null)
        {
            entidadeOfensora = new EntidadeOfensora(Id);
            await _entidadeOfensoraRepo.Insert(entidadeOfensora);
        }

        var gravitiesFromType = GetGravitiesFromType(result);

        var incidencias = gravitiesFromType.Select(typeAndGravity => new Incidencia(
            entidadeOfensora.Id,
            "",
            typeAndGravity.Key,
            typeAndGravity.Value,
            Text
        ));

        await _incidenciaRepository.InsertMany(incidencias);

        return !ViolateUnitLimit(result) && !ViolateSumLimit(result);
    }

    private Dictionary<TipoDeIncidencia, int> GetGravitiesFromType(ContentSafetyResult result) => 
        new Dictionary<TipoDeIncidencia, int>()
        {
            { TipoDeIncidencia.HATE, result.HateResult.Severity },
            { TipoDeIncidencia.SEXUAL, result.SexualResult.Severity },
            { TipoDeIncidencia.SELFHARM, result.SelfHarmResult.Severity },
            { TipoDeIncidencia.VIOLENCE, result.ViolenceResult.Severity },
        };
    
}
