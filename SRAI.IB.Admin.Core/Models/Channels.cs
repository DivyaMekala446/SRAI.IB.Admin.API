using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRAI.IB.Admin.Core.Models
{
    public class Channels
    {
        public int RetailerId { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
    }
}
