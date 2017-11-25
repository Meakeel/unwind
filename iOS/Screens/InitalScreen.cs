using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Unwind.iOS.Helpers;

namespace Unwind.iOS.Screens
{
    public partial class InitalScreen : BaseScreen<MessageViewModel>
    {
        private string apiResponse;

        public InitalScreen() : base("InitalScreen", false)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.LeftBarButtonItem = UIBarButtonItemHelpers.Create("Menu", () => base.SetupPicker());

            this.btnGo.TouchUpInside += async (object sender, EventArgs e) => await this.SendMessage();
        }

        public async Task SendMessage() 
        {
            var item = new ConversationItem
            {
                Input = this.txtInput.Text
            };

            Action setOpacityNone = () =>
            {
                this.viewText.Alpha = 0;
            };

            Action<object> setOpacityFull = (o) =>
            {
                this.OpacityFull();
            };


            UIViewPropertyAnimator propertyAnimatorOpacityNone = new UIViewPropertyAnimator(2, UIViewAnimationCurve.EaseInOut, setOpacityNone);

            propertyAnimatorOpacityNone.StartAnimation();

            var Response = await this.ViewModel.SendMessage(item);  

            TimerCallback abortPositionDelegate = new TimerCallback(setOpacityFull);
            Timer abortPosition = new Timer(abortPositionDelegate, null, 3000, Timeout.Infinite);

            this.apiResponse = Response;
            this.txtTitle.Text = this.apiResponse;
        }

        private void OpacityFull()
        {
            this.txtTitle.Text = this.apiResponse;

            Action setOpacityFull = () =>
            {
                this.viewText.Alpha = 1;
            };

            UIViewPropertyAnimator propertyAnimatorOpacityFull = new UIViewPropertyAnimator(4, UIViewAnimationCurve.EaseInOut, setOpacityFull);

            propertyAnimatorOpacityFull.StartAnimation();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

