namespace Unwind.iOS.Helpers
{
    using System;
    using UIKit;

    public static class UIBarButtonItemHelpers
    {
        public static UIBarButtonItem Empty => Create(string.Empty, null);

        public static UIBarButtonItem Create(string text, Action action)
        {
            var item = new UIBarButtonItem(text, UIBarButtonItemStyle.Plain, (sender, e) => action?.Invoke());

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Normal);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Focused);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Selected);

            return item;
        }

        public static UIBarButtonItem Create(string text, Action<UIBarButtonItem> action, bool passThroughView)
        {
            var item = new UIBarButtonItem(text, UIBarButtonItemStyle.Plain, null);

            item.Clicked += (sender, e) => action.Invoke(item);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Normal);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Focused);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Roboto-Regular", 17)
            }, UIControlState.Selected);

            return item;
        }
    }
}