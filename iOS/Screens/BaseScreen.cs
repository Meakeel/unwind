namespace Unwind.iOS.Screens
{
    using System;
    using UIKit;

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
    }
}