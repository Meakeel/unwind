using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unwind
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);    
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
