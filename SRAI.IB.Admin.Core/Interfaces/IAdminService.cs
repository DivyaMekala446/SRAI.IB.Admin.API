
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Admin.Core.Interfaces
{
    public interface IAdminService
    {
        Task<ResourcePermissions> GetMetadata(string[] resources, string solution, int retailerId, int clientId, RequestContext requestContext);
        Task<ResourcePermissions> GetList(string solution, int retailerId, int clientId, RequestContext? context);
        Task<ResourcePermissions> GetMetrics(string solution, int retailerId, int clientId);
        Task<ResourcePermissions> GetDimensions(string solution, int retailerId, int clientId);
        Task<ResourcePermissions> GetWidgets(string solution, int retailerId, int clientId);
        Task<DimensionPermissions> GetChannelsList(string solution, int retailerId, int clientId);
        Task<DimensionPermissions> GetSegments(string solution, int retailerId, int clientId);  
    }
}
