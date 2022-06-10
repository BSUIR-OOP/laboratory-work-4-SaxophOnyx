using System;

namespace DependencyInjectionLibrary.Exceptions
{
    public class UnregisteredTypeException: Exception
    {
        public UnregisteredTypeException()
            : base()
        {

        }

        public UnregisteredTypeException(string message)
            : base(message)
        {

        }
    }
}
