using System;

using UIKit;

namespace Unwind.iOS.Screens
{
    public partial class InitalScreen : BaseScreen<ItemsViewModel>
    {
        public InitalScreen() : base("InitalScreen", false)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

