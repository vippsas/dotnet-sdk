namespace Vipps.net.Exceptions
{
    public class VippsUserException : VippsBaseException
    {
        internal VippsUserException(string message = null, System.Exception innerException = null)
            : base(message, innerException) { }
    }
}
