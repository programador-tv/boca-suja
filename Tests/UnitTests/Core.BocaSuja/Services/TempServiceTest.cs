using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Factories;
using Core.BocaSuja.Models;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Core.BocaSuja.Tests.Factories
{
    [TestFixture]
    public class TempServiceTest
    {
        [Test]
        public void Validate_ReturnsBoolAways()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(c => c["AzureContentSafetyUrl"]).Returns("https://example.com");
            configurationMock
                .Setup(c => c["AzureContentSafetySubscriptionKey"])
                .Returns("subscription-key");
            configurationMock.Setup(c => c["AzureContentSafetyVersion"]).Returns("v1");

            var credentials = new AzureContentSafetyCredentials(configurationMock.Object);

            var context = LLMContextFactory.UseAzureContentSafety(credentials);
            var service = new TempService(context);
            // Act

            var result = service.Check(Guid.NewGuid(), "text");

            // Assert
            Assert.That(result, Is.InstanceOf<bool>());
            Assert.That(result, Is.True);
        }
    }
}
