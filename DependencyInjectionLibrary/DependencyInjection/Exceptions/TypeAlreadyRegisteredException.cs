using System;

namespace DependencyInjectionLibrary.Exceptions
{
    public class TypeAlreadyRegisteredException: Exception
    {
        public TypeAlreadyRegisteredException()
            : base()
        {

        }

        public TypeAlreadyRegisteredException(string message)
            : base(message)
        {

        }
    }
}
