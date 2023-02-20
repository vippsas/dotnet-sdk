namespace Vipps.net.Exceptions
{
    public abstract class VippsBaseException : System.Exception
    {
        internal VippsBaseException(string message = null, System.Exception innerException = null)
            : base(message, innerException) { }
    }
}
