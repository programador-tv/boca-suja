using System.Text;
using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Domain.Services;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.LLMContext;

public class AzureContentSafetyContext : IGenericLlmContext
{
    private AzureContentSafetyCredentials _credentials;
    private const int LIMIT_UNIT = 4;
    private const int LIMIT_SUM = 4;

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

    public AzureContentSafetyContext(AzureContentSafetyCredentials credentials)
    {
        _credentials = credentials;
    }

    public async Task<bool> Validate(string Id, string Text)
    {
        var result = await AzureContentSafetyService.CallAPI(
            Text,
            _credentials.GetURL(),
            _credentials.GetSubscriptionKey(),
            _credentials.GetVersion()
        );

        return !ViolateUnitLimit(result) && !ViolateSumLimit(result);
    }
}
