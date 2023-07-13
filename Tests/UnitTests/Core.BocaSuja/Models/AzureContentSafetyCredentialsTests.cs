using Core.BocaSuja.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Moq;

namespace Core.BocaSuja.Tests.Models
{
    [TestFixture]
    public class AzureContentSafetyCredentialsTests
    {
        [Test]
        public void Constructor_ValidConfiguration_InitializesProperties()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(c => c["AzureContentSafetyUrl"]).Returns("https://example.com");
            configurationMock
                .Setup(c => c["AzureContentSafetySubscriptionKey"])
                .Returns("subscription-key");
            configurationMock.Setup(c => c["AzureContentSafetyVersion"]).Returns("v1");

            // Act
            var credentials = new AzureContentSafetyCredentials(configurationMock.Object);
            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(credentials.URL, Is.EqualTo("https://example.com"));
                Assert.That(credentials.SubscriptionKey, Is.EqualTo("subscription-key"));
                Assert.That(credentials.Version, Is.EqualTo("v1"));
            });
        }

        [Test]
        public void Constructor_InvalidConfiguration_ThrowsException()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();

            // Act & Assert
            Assert.Throws<Exception>(
                () => new AzureContentSafetyCredentials(configurationMock.Object)
            );
        }
    }
}
