namespace AdvertisingSystem.Bll.Exceptions
{
    public class FailedLoginOrRegisterException : Exception
    {
        public FailedLoginOrRegisterException()
        {
        }

        public FailedLoginOrRegisterException(string message)
            : base(message)
        {
        }

        public FailedLoginOrRegisterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
