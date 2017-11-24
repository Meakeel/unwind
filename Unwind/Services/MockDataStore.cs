using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unwind
{
    public class MockDataStore : IDataStore<ConversationItem>
    {
        List<ConversationItem> items;

        public MockDataStore()
        {
            items = new List<ConversationItem>();
            var _items = new List<ConversationItem>
            {
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "First item" },
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "Second item" },
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "Third item" },
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "Fourth item" },
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "Fifth item" },
                new ConversationItem { Id = Guid.NewGuid().ToString(), Input = "Sixth item" },
            };

            foreach (ConversationItem item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(ConversationItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ConversationItem item)
        {
            var _item = items.Where((ConversationItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((ConversationItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<ConversationItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ConversationItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        Task<string> IDataStore<ConversationItem>.AddItemAsync(ConversationItem item)
        {
            throw new NotImplementedException();
        }
    }
}
