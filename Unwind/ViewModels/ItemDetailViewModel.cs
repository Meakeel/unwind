using System;

namespace Unwind
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ConversationItem Item { get; set; }
        public ItemDetailViewModel(ConversationItem item = null)
        {
            if (item != null)
            {
                Title = item.Input;
                Item = item;
            }
        }
    }
}
