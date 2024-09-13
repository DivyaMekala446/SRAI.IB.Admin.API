using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Interfaces.Services;

namespace SRAI.IB.Admin.Core.Services
{
    public class AdminService() : IAdminService
    {
        //ITenantService tenantService
        public string GetList(int retailerId, int clientId)
        {
            try
            {
                return "AdminAPI";
            }
          catch(Exception ex)
            {
                //logger.LogError(ex, "admin error");
                throw;
            }
        }
        public List<Channels> GetChannelsList(int retailerId, int clientId)
        {
            try
            {
                //var dbContext = tenantService.GetApplicationDbConnectionString();

                return new List<Channels>();
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "admin error");
                throw;
            }
        }
    }
}
