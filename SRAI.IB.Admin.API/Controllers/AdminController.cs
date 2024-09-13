using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Groups.Item.Team.Channels;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Common;

namespace SRAI.IB.Admin.API.Controllers
{
    /// <param name="adminService"></param>
    [ApiController]
    [Route("Admin/v1")]
    public class AdminController(IAdminService adminService) : Controller
    {
        [HttpGet]
        [Route("skills/{retailerId}/{clientId}")]
        public ResponseEnvelope Get(int retailerId, int clientId)
        {
            return ResponseEnvelope.Success(adminService.GetList(retailerId, clientId));
        }

        [HttpGet]
        [Route("channels/{retailerId}/{clientId}")]
        public List<Channels> GetChannels(int retailerId, int clientId)
        {
            return adminService.GetChannelsList(retailerId, clientId);
        }
    }
}
