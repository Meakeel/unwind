// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Unwind.iOS.Screens
{
    [Register ("InitalScreen")]
    partial class InitalScreen
    {
        [Outlet]
        UIKit.UILabel txtTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtTitle != null) {
                txtTitle.Dispose ();
                txtTitle = null;
            }
        }
    }
}