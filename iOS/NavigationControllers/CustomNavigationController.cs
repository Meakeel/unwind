namespace Unwind.iOS.NavigationControllers
{
    using System;
    using UIKit;

    public class CustomNavigationController : UINavigationController
    {
        public CustomNavigationController(UIViewController root, UIColor colour) : base(root)
        {
            this.NavigationBar.TintColor = UIColor.White;
            this.NavigationBar.TitleTextAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 15),
                ForegroundColor = UIColor.White
            };

            this.SetColour(colour);
        }

        public void SetColour(UIColor colour)
        {
            this.NavigationBar.BarTintColor = colour;
            this.NavigationBar.BackgroundColor = colour;
        }

        public void GoBackToViewController(UIViewController controller, bool animate = true)
        {
            var controllers = new UIViewController[] { controller, this.TopViewController };

            this.SetViewControllers(controllers, false);
            this.PopViewController(animate);
        }
    }
}
