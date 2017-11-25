using System;

using UIKit;
using Unwind.iOS.Helpers;

namespace Unwind.iOS.Screens
{
    public partial class ThrophiesScreen : BaseScreen<GernericViewModel>
    {
        public ThrophiesScreen() : base("ThrophiesScreen", false)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.LeftBarButtonItem = UIBarButtonItemHelpers.Create("Menu", () => base.SetupPicker());

            this.NavigationItem.RightBarButtonItem = UIBarButtonItemHelpers.Create("X", () => this.DismissViewController(true, null));

            this.imgThrophie.Image = UIImage.FromBundle("Throphie");
            this.imgThrophie.ContentMode = UIViewContentMode.ScaleToFill;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

