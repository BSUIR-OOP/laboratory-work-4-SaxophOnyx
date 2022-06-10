using System;
using System.Text;
using DependencyInjectionLibrary;
using DependencyInjectionLibrary.Exceptions;
using DependencyLab.Classes;

namespace DependencyInjectionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionContainer container = new DependencyInjectionContainer();
            container.RegisterType<StringBuilder>();
            container.RegisterType<string>();
            container.RegisterType<Inner>();
            container.RegisterType<Outer>();
            container.RegisterType<BeginCycle>();
            container.RegisterType<MiddleCycle>();
            container.RegisterType<EndCycle>();
            container.RegisterType<Singleton>();

            Inner inner = container.GetTransient<Inner>();
            Outer outer = container.GetTransient<Outer>();
            Outer outer2 = container.GetTransient<Outer>();
            Console.WriteLine("{0}", (outer == outer2));

            Singleton single = container.GetSingleton<Singleton>();
            Singleton single2 = container.GetSingleton<Singleton>();
            Console.WriteLine("{0}", (single == single2));

            try
            {
                BeginCycle cycle = container.GetTransient<BeginCycle>();
            }
            catch (CyclicDependencyException e)
            {
                Console.WriteLine("Cyclic Dependency");
            }

            Console.ReadKey();
        }
    }
}
