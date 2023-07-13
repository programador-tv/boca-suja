namespace Core.BocaSuja.Models;

using Microsoft.Extensions.Configuration;

public class AzureContentSafetyCredentials
{
    public string URL;
    public string SubscriptionKey;
    public string Version;

    public AzureContentSafetyCredentials(IConfiguration configuration)
    {
        var AzureContentSafetyUrl =
            Environment.GetEnvironmentVariable("AzureContentSafetyUrl")
            ?? configuration["AzureContentSafetyUrl"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetyUrl))
            throw new Exception(
                "AzureContentSafetyUrl is not defined in appsettings.json or environment variables"
            );

        var AzureContentSafetySubscriptionKey =
            Environment.GetEnvironmentVariable("AzureContentSafetySubscriptionKey")
            ?? configuration["AzureContentSafetySubscriptionKey"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetySubscriptionKey))
            throw new Exception(
                "AzureContentSafetySubscriptionKey is not defined in appsettings.json or environment variables"
            );

        var AzureContentSafetyVersion =
            Environment.GetEnvironmentVariable("AzureContentSafetyVersion")
            ?? configuration["AzureContentSafetyVersion"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetyVersion))
            throw new Exception(
                "AzureContentSafetyVersion is not defined in appsettings.json or environment variables"
            );

        URL = AzureContentSafetyUrl;
        SubscriptionKey = AzureContentSafetySubscriptionKey;
        Version = AzureContentSafetyVersion;
    }
}
