using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Groups.Item.Team.Channels;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;

namespace SRAI.IB.Admin.API.Controllers
{
    /// <param name="adminService"></param>
    [ApiController]
    [Route("admin/v1")]
    public class AdminController(IAdminService adminService) : Controller
    {
        [HttpGet]
        [Route("api")]
        public string Get()
        {
            return adminService.GetList();
        }

        [HttpGet]
        [Route("api/channels/{retailerId}/{clientId}")]
        public List<Channels> GetChannels(int retailerId, int clientId)
        {
            return adminService.GetChannelsList(retailerId, clientId);
        }
    }
}
