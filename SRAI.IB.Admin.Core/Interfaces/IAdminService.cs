
using SRAI.IB.Admin.Core.Models;

namespace SRAI.IB.Admin.Core.Interfaces
{
    public interface IAdminService
    {
        string GetList(int retailerId, int clientId);
        List<Channels> GetChannelsList(int retailerId, int clientId);
    }
}
