using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Admin.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<ResourcePermissions> GetSkillsList(string solution, int retailerId, int clientId, RequestContext? context);
    }
}
