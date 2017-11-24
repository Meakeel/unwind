using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unwind
{
    public interface IDataStore<T>
    {
        Task<string> AddItemAsync(T item);
    }
}
