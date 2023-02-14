using Microsoft.Extensions.Logging;

namespace Vipps.net.Infrastructure
{
    internal static class VippsLogging
    {
        internal static ILoggerFactory _loggerFactory;
        internal static ILoggerFactory LoggerFactory
        {
            get { return _loggerFactory; }
            set { _loggerFactory = value; }
        }
    }
}
