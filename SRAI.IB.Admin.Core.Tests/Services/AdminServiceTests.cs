using Moq;
using Newtonsoft.Json;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Admin.Core.Services;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Admin.Core.Tests.Services
{
    public class AdminServiceTests
    {
        private readonly Mock<IAdminRepository> _moqAdminRepository;

        public AdminServiceTests()
        {
            _moqAdminRepository = new Mock<IAdminRepository>();
        }

        [Fact]
        public async Task Admin_Skills_ReturnsSuccessResponse()
        {
            string solution = "IB";
            int retailerId = 48;
            int clientId = 1;
            var requestContext = new RequestContext();
            var expectedResponse = new ResourcePermissions();

            _moqAdminRepository
                .Setup(x => x.GetSkillsList(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<RequestContext>()))
                 .ReturnsAsync(new ResourcePermissions());

            var services = new AdminService(
                _moqAdminRepository.Object);

            // Act
            var result = await services.GetList(solution, retailerId, clientId, requestContext);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(result));
        }
    }
}
