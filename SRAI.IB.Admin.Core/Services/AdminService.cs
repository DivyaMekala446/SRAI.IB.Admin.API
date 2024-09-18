using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Models.Contexts;

namespace SRAI.IB.Admin.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="coreDependencies"></param>
    /// <param name="adminRepository"></param>
    public class AdminService(IAdminRepository adminRepository) : IAdminService
    {


        public async Task<ResourcePermissions> GetMetadata(string[] resources, string solution, int retailerId, int clientId, RequestContext requestContext)
        {
            try
            {
                if (resources.Contains(Constants.Resources.Metrics))
                {
                    return await GetMetrics(solution, retailerId, clientId);
                }
                if (resources.Contains(Constants.Resources.Skills))
                {
                    return await GetList(solution, retailerId, clientId, requestContext);
                }
                if (resources.Contains(Constants.Resources.Widgets))
                {
                    return await GetWidgets(solution, retailerId, clientId);
                }
                if (resources.Contains(Constants.Resources.Dimensions))
                {
                    return await GetDimensions(solution, retailerId, clientId);
                }
                return new ResourcePermissions();
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "admin error");
                throw ex;
            }
        }

        public async Task<ResourcePermissions> GetList(string solution, int retailerId, int clientId, RequestContext? context)
        {
            try
            {
                return await adminRepository.GetSkillsList(solution, retailerId, clientId, context!);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ResourcePermissions> GetMetrics(string solution, int retailerId, int clientId)
        {
            var metrics = new ResourcePermissions
            {
                Type = "metrics",
                Rows = new List<Permissions>
                {
                   new Permissions
                      {
                          ResourceName = "sales",
                          Permission = ["read"]
                      }
                }
            };

            // Update each Permissions entry with new resource names
            foreach (var permission in metrics.Rows)
            {
                permission.ResourceName = GenerateMetricVariant(
                    permission.ResourceName,
                    "_ty",
                    "_ly",
                    "_chg",
                    "_chg_pct"
                );
            }

            // Method to generate updated resource names
            string GenerateMetricVariant(string baseName, params string[] suffixes)
            {
                var updatedNames = suffixes.Select(suffix => $"{baseName}{suffix}");
                return string.Join(", ", updatedNames);
            }
            return metrics;

        }
        public async Task<ResourcePermissions> GetDimensions(string solution, int retailerId, int clientId)
        {
            return new ResourcePermissions();
        }
        public async Task<ResourcePermissions> GetWidgets(string solution, int retailerId, int clientId)
        {
            return new ResourcePermissions();
        }
        public async Task<DimensionPermissions> GetChannelsList(string solution, int retailerId, int clientId)
        {
            try
            {
                return new DimensionPermissions();
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "admin error");
                throw;
            }
        }
        public async Task<DimensionPermissions> GetSegments(string solution, int retailerId, int clientId)
        {
            return new DimensionPermissions();
        }
    }
}
