using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.API.Controllers;
using SRAI.IB.Core.Common;
using SRAI.IB.Core.Interfaces.Services;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Admin.API.Controllers
{
    /// <param name="adminService"></param>
    /// <param name="tenantService"></param>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("admin/v1")]
    public class AdminController(IAdminService adminService, ITenantService tenantService) : ApiBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("metadata/" + RouteParams.RetailerIdSlashClientId)]
        public async Task<ResponseEnvelope> GetMetadata([FromBody] string[] resources, int retailerId, int clientId)
        {
            var solution = "IB";
            var requestContext = await tenantService.GetV1RequestContext(retailerId, clientId);
            return ResponseEnvelope.Success(await adminService.GetMetadata(resources, solution, retailerId, clientId, requestContext));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("skills/" + RouteParams.RetailerIdSlashClientId)]
        public async Task<ResponseEnvelope> GetSkills([FromBody] string solution, int retailerId, int clientId)
        {
            var requestContext = new RequestContext();//await tenantService.GetV1RequestContext(retailerId, clientId);
            return ResponseEnvelope.Success(await adminService.GetList(solution, retailerId, clientId, requestContext!));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("metrics/" + RouteParams.RetailerIdSlashClientId)]
        public async Task<ResponseEnvelope> GetMetrics([FromBody] string solution, int retailerId, int clientId)
        {
            //var context = await tenantService.GetRequestContext(retailerId, clientId);
            return ResponseEnvelope.Success( await adminService.GetMetrics(solution, retailerId, clientId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("dimensions/" + RouteParams.RetailerIdSlashClientId)]
        public async Task<ResponseEnvelope> GetDimensions([FromBody] string solution, int retailerId, int clientId)
        {
            //var context = await tenantService.GetRequestContext(retailerId, clientId);
            return ResponseEnvelope.Success(await adminService.GetDimensions(solution, retailerId, clientId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("channels/" + RouteParams.RetailerIdSlashClientId)]
        public async Task<ResponseEnvelope> GetChannels([FromBody] string solution, int retailerId, int clientId)
        {
            //var context = await tenantService.GetRequestContext(retailerId, clientId);
            return ResponseEnvelope.Success(await adminService.GetChannelsList(solution, retailerId, clientId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("segments/{retailerId}/{clientId}")]
        public async Task<ResponseEnvelope> GetSegments([FromBody] string solution, int retailerId, int clientId)
        {
            return ResponseEnvelope.Success(await adminService.GetSegments(solution, retailerId, clientId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="retailerId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("widgets/{retailerId}/{clientId}")]
        public async Task<ResponseEnvelope> GetWidgets([FromBody] string solution, int retailerId, int clientId)
        {
            return ResponseEnvelope.Success(await adminService.GetWidgets(solution, retailerId, clientId));
        }
    }
}
