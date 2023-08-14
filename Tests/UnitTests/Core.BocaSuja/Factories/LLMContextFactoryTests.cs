using Core.BocaSuja.LLMContext;
using Core.BocaSuja.Factories;
using Core.BocaSuja.Models;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Core.BocaSuja.Tests.Factories
{
    [TestFixture]
    public class LLMContextFactoryTests
    {
        // [Test]
        // public void UseAzureContentSafety_ReturnsInstanceOfAzureContentSafetyContext()
        // {
        //     // Arrange
        //     var configurationMock = new Mock<IConfiguration>();
        //     configurationMock.Setup(c => c["AzureContentSafetyUrl"]).Returns("https://example.com");
        //     configurationMock
        //         .Setup(c => c["AzureContentSafetySubscriptionKey"])
        //         .Returns("subscription-key");
        //     configurationMock.Setup(c => c["AzureContentSafetyVersion"]).Returns("v1");

        //     // Act
        //     var credentials = new AzureContentSafetyCredentials(configurationMock.Object);

        //     // Act
        //     var result = LLMContextFactory.UseAzureContentSafety(credentials);

        //     // Assert
        //     Assert.That(result, Is.InstanceOf<AzureContentSafetyContext>());
        // }
    }
}
