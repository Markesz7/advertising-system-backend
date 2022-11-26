namespace AdvertisingSystem.Bll.Exceptions
{
    public class UserNotEnabledException : Exception
    {
        public UserNotEnabledException()
        {
        }

        public UserNotEnabledException(string message)
            : base(message)
        {
        }

        public UserNotEnabledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
