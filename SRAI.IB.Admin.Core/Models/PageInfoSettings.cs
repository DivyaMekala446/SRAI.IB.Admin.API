using SRAI.IB.Core.Models.Settings;

namespace SRAI.IB.Admin.Core.Models
{
    public class PageInfoSetting
    {
        private string _defaultSortOrder = "";

        public string DefaultSortOrder
        {
            get => _defaultSortOrder;
            set => BaseAppSettings.SetProperty(ref _defaultSortOrder, value);
        }

        private int _pageSize = 100;

        public int PageSize
        {
            get => _pageSize;
            set => BaseAppSettings.SetProperty(ref _pageSize, value);
        }

        private int _pageNumber = 1;

        public int PageNumber
        {
            get => _pageNumber;
            set => BaseAppSettings.SetProperty(ref _pageNumber, value);
        }

        private string _orderByDesc = "";

        public string OrderByDesc
        {
            get => _orderByDesc;
            set => BaseAppSettings.SetProperty(ref _orderByDesc, value);
        }

        private string _orderByAsc = "";

        public string OrderByAsc
        {
            get => _orderByAsc;
            set => BaseAppSettings.SetProperty(ref _orderByAsc, value);
        }
    }
}
