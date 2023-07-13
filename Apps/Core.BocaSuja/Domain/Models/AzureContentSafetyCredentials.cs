namespace Core.BocaSuja.Models;

using Microsoft.Extensions.Configuration;

public class AzureContentSafetyCredentials
{
    private readonly string URL;
    private readonly string SubscriptionKey;
    private readonly string Version;

    public AzureContentSafetyCredentials(IConfiguration configuration)
    {
        var AzureContentSafetyUrl =
            Environment.GetEnvironmentVariable("AzureContentSafetyUrl")
            ?? configuration["AzureContentSafetyUrl"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetyUrl))
            throw new ArgumentNullException(
                nameof(configuration),
                "AzureContentSafetyUrl is not defined in appsettings.json or environment variables"
            );

        var AzureContentSafetySubscriptionKey =
            Environment.GetEnvironmentVariable("AzureContentSafetySubscriptionKey")
            ?? configuration["AzureContentSafetySubscriptionKey"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetySubscriptionKey))
            throw new ArgumentNullException(
                nameof(configuration),
                "AzureContentSafetySubscriptionKey is not defined in appsettings.json or environment variables"
            );

        var AzureContentSafetyVersion =
            Environment.GetEnvironmentVariable("AzureContentSafetyVersion")
            ?? configuration["AzureContentSafetyVersion"]
            ?? string.Empty;

        if (string.IsNullOrEmpty(AzureContentSafetyVersion))
            throw new ArgumentNullException(
                nameof(configuration),
                "AzureContentSafetyVersion is not defined in appsettings.json or environment variables"
            );

        URL = AzureContentSafetyUrl;
        SubscriptionKey = AzureContentSafetySubscriptionKey;
        Version = AzureContentSafetyVersion;
    }

    public string GetURL()
    {
        return URL;
    }

    public string GetSubscriptionKey()
    {
        return SubscriptionKey;
    }

    public string GetVersion()
    {
        return Version;
    }
}
