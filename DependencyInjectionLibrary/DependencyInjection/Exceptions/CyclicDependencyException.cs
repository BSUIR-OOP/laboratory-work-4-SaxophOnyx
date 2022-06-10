using System;

namespace DependencyInjectionLibrary.Exceptions
{
    public class CyclicDependencyException: Exception
    {
        public CyclicDependencyException()
            : base()
        {

        }

        public CyclicDependencyException(string message)
            : base(message)
        {

        }
    }
}
