using System;
using System.Threading.Tasks;
using UIKit;

namespace Unwind.iOS.Screens
{
    public partial class InitalScreen : BaseScreen<MessageViewModel>
    {
        public InitalScreen() : base("InitalScreen", false)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.btnGo.TouchUpInside += async (object sender, EventArgs e) => await this.SendMessage();
        }

        public async Task SendMessage() 
        {
            var item = new ConversationItem
            {
                Input = this.txtInput.Text
            };

            var Response = await this.ViewModel.SendMessage(item);

            this.txtTitle.Text = Response;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

