using Vipps.Models;

namespace Vipps.net.Infrastructure
{
    public static class VippsConfigurationHolder
    {
        public static VippsConfiguration VippsConfiguration { get; set; }

        private static IVippsClient? _vippsClient;
        public static IVippsClient VippsClient
        {
            get
            {
                if (_vippsClient is null)
                {
                    _vippsClient = CreateDefaultVippsClient();
                }

                return _vippsClient;
            }
            set
            {
                if (_vippsClient is not null)
                {
                    throw new InvalidOperationException("Once created, VippsClient cannot be modified");
                }
                _vippsClient = value;
            }
        }

        private static IVippsClient CreateDefaultVippsClient()
        {
            return new VippsClient();
        }
    }
}
