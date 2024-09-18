using SRAI.IB.Core.Data.Services;
using SRAI.IB.Core.Interfaces.Services;

namespace SRAI.IB.Admin.Core
{
    public class AdminCoreDependencies( ITenantService tenantService, IApplicationDbService applicationDbService)
    {
        public readonly ITenantService TenantService = tenantService;
        public readonly IApplicationDbService applicationDbService = applicationDbService;
    }
}
