using Moq;
using Newtonsoft.Json;
using SRAI.IB.Admin.API.Controllers;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Common;
using SRAI.IB.Core.Interfaces.Services;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Dimensions.API.Tests.Controllers.v1
{
    public class AdminControllerTests
    {
        private readonly Mock<IAdminService> _adminServiceMock;
        private readonly Mock<ITenantService> _mockTenantService;

        public AdminControllerTests()
        {
            _adminServiceMock = new Mock<IAdminService>();
            _mockTenantService = new Mock<ITenantService>();
        }

        [Fact]
        public async Task Admin_metadata_ReturnsSuccessResponse()
        {
            // Arrange
            string[] resources = ["skills"];
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new ResourcePermissions());

            _adminServiceMock
                .Setup(x => x.GetMetadata(It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<RequestContext>()))
                 .ReturnsAsync(new ResourcePermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetMetadata(resources, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }


        [Fact]
        public async Task Admin_Skills_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new ResourcePermissions());

            _adminServiceMock
                .Setup(x => x.GetList(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<RequestContext>()))
                 .ReturnsAsync(new ResourcePermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetSkills(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Admin_dimensions_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new ResourcePermissions());

            _adminServiceMock
                .Setup(x => x.GetDimensions(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                 .ReturnsAsync(new ResourcePermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetDimensions(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Admin_channels_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new DimensionPermissions());

            _adminServiceMock
                .Setup(x => x.GetChannelsList(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                 .ReturnsAsync(new DimensionPermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetChannels(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Admin_segments_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new DimensionPermissions());

            _adminServiceMock
                .Setup(x => x.GetSegments(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                 .ReturnsAsync(new DimensionPermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetSegments(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Admin_widgets_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new ResourcePermissions());

            _adminServiceMock
                .Setup(x => x.GetWidgets(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                 .ReturnsAsync(new ResourcePermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetWidgets(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Admin_metrics_ReturnsSuccessResponse()
        {
            // Arrange
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var expectedResponse = ResponseEnvelope.Success(new ResourcePermissions());

            _adminServiceMock
                .Setup(x => x.GetMetrics(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                 .ReturnsAsync(new ResourcePermissions());

            var controller = new AdminController(
                _adminServiceMock.Object,
                _mockTenantService.Object);

            // Act
            var result = await controller.GetMetrics(solution, retailerId, clientId);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }
    }
}
