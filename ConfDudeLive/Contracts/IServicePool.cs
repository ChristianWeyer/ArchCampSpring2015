
namespace Contracts
{
    public interface IServicePool
    {
        void AddService<T>(T service);
        T GetService<T>();
    }
}
