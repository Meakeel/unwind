// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Unwind.iOS.Screens
{
	[Register ("InitalScreen")]
	partial class InitalScreen
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtInput { get; set; }

		[Outlet]
		UIKit.UILabel txtTitle { get; set; }

		[Outlet]
		UIKit.UIView viewText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (txtInput != null) {
				txtInput.Dispose ();
				txtInput = null;
			}

			if (txtTitle != null) {
				txtTitle.Dispose ();
				txtTitle = null;
			}

			if (viewText != null) {
				viewText.Dispose ();
				viewText = null;
			}
		}
	}
}
