namespace Vipps.net.Exceptions
{
    public class VippsTechnicalException : VippsBaseException
    {
        internal VippsTechnicalException(
            string message = null,
            System.Exception innerException = null
        )
            : base(message, innerException) { }
    }
}
