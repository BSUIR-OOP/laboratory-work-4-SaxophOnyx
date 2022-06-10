using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DependencyInjectionLibrary.Exceptions;

namespace DependencyInjectionLibrary
{
    public class DependencyInjectionContainer
    {
        private Dictionary<Type, object> _singletons;

        private Dictionary<Type, ConstructorInfo> _constructors;


        public DependencyInjectionContainer()
        {
            _singletons = new Dictionary<Type, object>();
            _constructors = new Dictionary<Type, ConstructorInfo>();
        }


        public void RegisterType<T>()
        {
            Type type = typeof(T);
            if (_constructors.ContainsKey(type))
                throw new TypeAlreadyRegisteredException();

            _constructors.Add(type, GetMinConstructor(type));
        }


        public T GetTransient<T>()
        {
            return (T)CreateObject(typeof(T), new HashSet<Type>());
        }

        public T GetSingleton<T>()
        {
            Type type = typeof(T);

            if (!_singletons.TryGetValue(type, out var result))
            {
                var obj = (T)CreateObject(type, new HashSet<Type>());
                _singletons.Add(type, obj);
                return obj;
            }
            else
                return (T)result;
        }

        private object CreateObject(Type type, HashSet<Type> types)
        {
            if (types.Contains(type))
                throw new CyclicDependencyException();

            if (TryGetDefaultValue(type, out object obj))
                return obj;

            if (_constructors.TryGetValue(type, out ConstructorInfo constructor))
            {
                List<object> parameters = new List<object>();

                foreach (var paramInfo in constructor.GetParameters())
                {
                    Type paramType = paramInfo.ParameterType;
                    types.Add(type);
                    object paramInstance = CreateObject(paramType, types);
                    parameters.Add(paramInstance);
                    types.Remove(type);
                }

                return constructor.Invoke(parameters.ToArray());
            }
            else
                throw new UnregisteredTypeException();
        }

        private ConstructorInfo GetMinConstructor(Type type)
        {
            var list = type.GetConstructors();
            var res = list.FirstOrDefault();

            foreach (var item in list)
            {
                if (item.GetParameters().Length < res.GetParameters().Length)
                    res = item;
            }

            return res;
        }

        private bool TryGetDefaultValue(Type type, out object result)
        {
            if (type.Equals(typeof(string)))
            {
                result = default(string);
                return true;
            }
            else if (type.IsValueType)
            {
                result = Activator.CreateInstance(type);
                return true;
            }

            result = null;
            return false;
        }
    }
}
