using Microsoft.Extensions.DependencyInjection;
using SRAI.IB.Admin.Core.Interfaces;
using SRAI.IB.Admin.Core.Repository;
using SRAI.IB.Admin.Core.Services;
using System.Diagnostics.CodeAnalysis;

namespace SRAI.IB.Admin.Core
{
    public static class AdminCoreDependencyResolution
    {
        [ExcludeFromCodeCoverage]
        public static void ResolveAdminCore(this IServiceCollection services)
        {
            services.AddTransient<AdminCoreDependencies>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }
    }
}
