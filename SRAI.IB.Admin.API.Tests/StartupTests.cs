using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SRAI.IB.Admin.API;
using SRAI.IB.Core.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SRAI.IB.Admin.Api.Tests
{
    public class StartupTests
    {
        [Fact]
        public void TestStartupConstructor()
        {
            // Arrange
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(env => env.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            envMock.Setup(env => env.EnvironmentName).Returns("Development");

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(config => config.GetSection("AppSettings"))
                .Returns(new Mock<IConfigurationSection>().Object);

            // Act
            var startup = new Startup(envMock.Object);

            // Assert
            Assert.NotNull(startup);
            Assert.Equal("v1", startup.ApiVersion);
            Assert.Equal("Insights Builder Admin API", startup.ApiName);
            Assert.Equal("admin", startup.SwaggerRoutePrefix());
        }


        [Fact]
        public void Startup_AddSwaggerServers_AddsServerDetailsToOptions()
        {
            // Arrange
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(env => env.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            envMock.Setup(env => env.EnvironmentName).Returns("Development");

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(config => config.GetSection("AppSettings"))
                .Returns(new Mock<IConfigurationSection>().Object);

            // Act
            var startup = new Startup(envMock.Object);

            var swaggerCollection = new SwaggerGenOptions();
            startup.AddSwaggerServers(swaggerCollection);

            Assert.True(swaggerCollection.SwaggerGeneratorOptions.Servers.Count > 1);
        }

        [Fact]
        public void Startup_ResolveLocalServices_ResolvesDependencyInjectionForLocalServicesByCallingExtensions()
        {
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(env => env.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            envMock.Setup(env => env.EnvironmentName).Returns("Development");

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(config => config.GetSection("AppSettings"))
                .Returns(new Mock<IConfigurationSection>().Object);

            var serviceMock = new Mock<IServiceCollection>();

            var startup = new Startup(envMock.Object);

            startup.ResolveLocalServices(serviceMock.Object);

            serviceMock.VerifyAll();
        }

        [Fact]
        public void Startup_AddSwaggerDoc_UpdateSwaggerCollectionWithExpectedDetails()
        {
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(env => env.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            envMock.Setup(env => env.EnvironmentName).Returns("Development");

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(config => config.GetSection("AppSettings"))
                .Returns(new Mock<IConfigurationSection>().Object);

            var startup = new Startup(envMock.Object);

            var swaggerCollection = new SwaggerGenOptions();
            startup.AddSwaggerDoc(swaggerCollection);

            var swagDoc = swaggerCollection.SwaggerGeneratorOptions.SwaggerDocs.First();
            Assert.Equal("v1", swagDoc.Key);
            Assert.Equal("v1", swagDoc.Value.Version);
            Assert.Equal("Insights Builder Admin API", swagDoc.Value.Description);
            Assert.Equal("Insights Builder Admin API", swagDoc.Value.Title);
        }

        [Fact]
        public void IsAllowedDomain_ReturnsTrue_WhenRequestOriginIsInWhitelistedDomains()
        {
            // Arrange
            var requestOrigin = "https://www.example.com";
            var whiteListedDomains = "example.com,example.org,example.net";

            // Act
            var result = requestOrigin.IsAllowedDomain(whiteListedDomains);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAllowedDomain_ReturnsFalse_WhenRequestOriginIsNotInWhitelistedDomains()
        {
            // Arrange
            var requestOrigin = "https://www.example.com";
            var whiteListedDomains = "example.org,example.net";

            // Act
            var result = requestOrigin.IsAllowedDomain(whiteListedDomains);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsAllowedDomain_ThrowsArgumentException_WhenRequestOriginIsNullOrEmpty()
        {
            // Arrange
            string? requestOrigin = null;
            var whiteListedDomains = "example.com";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => requestOrigin!.IsAllowedDomain(whiteListedDomains));

            requestOrigin = string.Empty;
            Assert.Throws<ArgumentException>(() => requestOrigin.IsAllowedDomain(whiteListedDomains));
        }

        [Fact]
        public void IsAllowedDomain_ThrowsArgumentException_WhenWhiteListedDomainsIsNullOrEmpty()
        {
            // Arrange
            var requestOrigin = "https://www.example.com";
            string? whiteListedDomains = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => requestOrigin.IsAllowedDomain(whiteListedDomains!));

            whiteListedDomains = string.Empty;
            Assert.Throws<ArgumentException>(() => requestOrigin.IsAllowedDomain(whiteListedDomains));
        }
    }
}
