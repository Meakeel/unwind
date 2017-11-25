namespace Unwind.iOS.Screens
{
    using System;
    using UIKit;
    using Unwind.iOS.NavigationControllers;

    public abstract class BaseScreen<T> : UIViewController
        where T : BaseViewModel, new()
    {
        private T vm;
        private readonly bool resize;

        public BaseScreen(string nib, bool resize) : base(nib, null)
        {
            this.resize = resize;
        }

        public bool ShowBackButton { get; set; } = false;

        protected T ViewModel
        {
            get
            {
                if (this.vm == null)
                {
                    this.vm = new T();
                }

                return this.vm;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gesture = new UITapGestureRecognizer(() => this.View.EndEditing(true));

            gesture.CancelsTouchesInView = false;

            this.View.AddGestureRecognizer(gesture);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.NavigationController != null)
            {
                this.NavigationItem.HidesBackButton = !this.ShowBackButton;
            }
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            if (this.resize && this.View.Frame.Width > 414)
            {
                var width = this.View.Frame.Width;
                var x = (width / 2) - 207;

                this.View.Frame = new CoreGraphics.CGRect(x, this.View.Frame.Y, 414, this.View.Frame.Height);
            }
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }


        public void SetupPicker()
        {
            var picker = UIAlertController.Create("Menu", string.Empty, UIAlertControllerStyle.ActionSheet);
            picker.AddAction(UIAlertAction.Create("Home", UIAlertActionStyle.Default, (obj) => this.GoToHome()));
            picker.AddAction(UIAlertAction.Create("Breath", UIAlertActionStyle.Default, (obj) => this.Todo()));
            picker.AddAction(UIAlertAction.Create("Notepad", UIAlertActionStyle.Default, (obj) => this.Todo()));
            picker.AddAction(UIAlertAction.Create("Trophies", UIAlertActionStyle.Default, (obj) => this.GoToTrophies()));
            picker.AddAction(UIAlertAction.Create("About", UIAlertActionStyle.Default, (obj) => this.Todo()));

            this.PresentViewController(picker, true, null);
        }

        private void ClosePicker()
        {
            return;
        }

        private void Todo()
        {
            new UIAlertView("Come back later", "We are adding new functionality all the time please come back later", null, "OK").Show();
            return;
        }

        private void GoToHome()
        {
            this.PresentViewController(new CustomNavigationController(new InitalScreen(), ColourPalette.Blue), true, null);

        }

        private void GoToTrophies()
        {
            this.PresentViewController(new CustomNavigationController(new ThrophiesScreen(), ColourPalette.Blue), true, null);
        }
    }
}