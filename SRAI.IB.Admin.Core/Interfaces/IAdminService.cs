
using SRAI.IB.Admin.Core.Models;

namespace SRAI.IB.Admin.Core.Interfaces
{
    public interface IAdminService
    {
        string GetList();
        List<Channels> GetChannelsList(int retailerId, int clientId);
    }
}
