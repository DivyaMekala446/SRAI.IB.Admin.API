using SRAI.IB.Core.Models.Settings;

namespace SRAI.IB.Admin.Core.Models
{
    public class AdminAppSettings : CoreAppSettings
    {
        public PageInfoSetting PageInfoSetting { get; set; } = new();
    }
}
