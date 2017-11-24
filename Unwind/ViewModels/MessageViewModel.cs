using System;
using System.Threading.Tasks;

namespace Unwind
{
    public class MessageViewModel : BaseViewModel
    {
        public ConversationItem Item { get; set; }

        public async Task<string> SendMessage(ConversationItem input)
        {
            var message = await this.DataStore.AddItemAsync(input);

            return message;
        }
    }
}
