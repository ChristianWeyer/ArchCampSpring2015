using Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfDude.Services
{
    public class ServicePool : IServicePool
    {
        private static ServicePool _current;
        private static object _lockObject = new object();
        private ConcurrentDictionary<Type, object> _services;

        private ServicePool()
        {
            _services = new ConcurrentDictionary<Type, object>();
        }

        public static ServicePool Current
        {
            get
            {
                lock (_lockObject)
                {
                    if (_current == null)
                        _current = new ServicePool();
                    return _current;
                }
            }
        }

        public void AddService<T>(T service)
        {
            _services.TryAdd(typeof(T), service);
        }

        public T GetService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T)_services[typeof(T)];
            }
            return default(T);
        }
    }
}
