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
	[Register ("ThrophiesScreen")]
	partial class ThrophiesScreen
	{
		[Outlet]
		UIKit.UIImageView imgThrophie { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgThrophie != null) {
				imgThrophie.Dispose ();
				imgThrophie = null;
			}
		}
	}
}
