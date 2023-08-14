using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Params;
using Core.BocaSuja.Infrastructure.Context;
using Core.BocaSuja.Infrastructure.Repositories.Interfaces;
using Core.BocaSuja.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Core.BocaSuja.Infrastructure.Repositories;

public sealed class IncidenciaRepository : IIncidenciaRepository
{
    private readonly BocaSujaDbContext _db;

    public IncidenciaRepository(BocaSujaDbContext db)
    {
        _db = db;
    }

    // TODO: Talvez implementar paginação
    public IQueryable<Incidencia> Select() => _db.Incidencias.Where(x => x.Inativo == false);

    public async Task<Incidencia?> Select(Guid id) =>
        await Select().FirstOrDefaultAsync(x => x.Id == id);

    // TODO: Talvez implementar paginação e/ou outras regras
    public IQueryable<Incidencia> Select(IncidenciaParams? @params)
    {
        IQueryable<Incidencia> query = Select();

        if (@params != null)
        {
            query = query
                .WhereIf(@params.Id.HasValue, x => x.Id == @params.Id!.Value)
                .WhereIf(
                    @params.EntidadeOfensora.HasValue,
                    x => x.EntidadeOfensora == @params.EntidadeOfensora!.Value
                )
                .WhereIf(@params.Inativo.HasValue, x => x.Inativo == @params.Inativo!.Value)
                .WhereIf(@params.Gravidade.HasValue, x => x.Gravidade == @params.Gravidade!.Value)
                .WhereIf(@params.Tipo.HasValue, x => x.Tipo == @params.Tipo!.Value)
                .WhereIf(
                    !@params.Recurso.IsNullOrEmpty(),
                    x => x.Recurso.Equals(@params.Recurso, StringComparison.OrdinalIgnoreCase)
                )
                .WhereIf(
                    !@params.Texto.IsNullOrEmpty(),
                    x => x.Texto.Equals(@params.Texto, StringComparison.OrdinalIgnoreCase)
                );
        }

        return query;
    }

    public async Task Insert(Incidencia obj)
    {
        try
        {
            await _db.Incidencias.AddAsync(obj);
            await _db.SaveChangesAsync();
        }
        // TODO: Exception Handler
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
    }
    
    public async Task InsertMany(IEnumerable<Incidencia> objs)
    {
        try
        {
            await _db.Incidencias.AddRangeAsync(objs);
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task Update(Guid id, IncidenciaParams obj)
    {
        // TODO: Implementar Update
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        // TODO: Implementar Delete
        throw new NotImplementedException();
    }
}
