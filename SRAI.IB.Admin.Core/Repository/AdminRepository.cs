using DocumentFormat.OpenXml.Wordprocessing;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Models;
using SRAI.IB.Core.Models.Contexts;
using System.Data;

namespace SRAI.IB.Admin.Core.Repository
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="adminCoreDependencies"></param>
    public class AdminRepository(AdminCoreDependencies adminCoreDependencies) : IAdminRepository
    {
        public async Task<ResourcePermissions> GetSkillsList(string solution, int retailerId, int clientId, RequestContext? context)
        {
            //var param = new
            //{
            //    userId = "mekala.divya@symphonyretailai.com",
            //    retailerId = 48,
            //    clientId = 1,
            //    boardId = 30118,
            //    boardName = "Untitled-127",
            //    exportName = "x",
            //    widgetName ="Datagrid",
            //    pGRIds = 1,
            //    IsCombinedPgrExport = 1
            //};

            //var result = adminCoreDependencies.applicationDbService.ExecuteScalarAsync<long>(
            //    "[COPILOT].[usp_InsertBatchExportHistory]",
            //    param,
            //    commandType: CommandType.StoredProcedure,
            //    overrideFullDbConStrOrCacheKeyOrSnfTokenCacheKey: context!.ApplicationDbConnectionString);
            var resource = new ResourcePermissions
            {
                Type = "skills",
                Rows = new List<Permissions>
                {
                    new Permissions
                    {
                        ResourceName = "SALES AND CUSTOMER",
                        Permission = ["read"]
                    },
                    new Permissions
                    {
                        ResourceName = "ASSORTMENT",
                        Permission = ["read"]
                    }
                }
            };
            return resource;
        }
    }
}
