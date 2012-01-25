// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace IKHealth
{
	[Register ("IKHealthViewController")]
	partial class IKHealthViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _loginButton { get; set; }

		[Outlet]
		IKHealth.IKTextField _usernameField { get; set; }

		[Outlet]
		IKHealth.IKTextField _passwordField { get; set; }

		[Action ("textFieldDidBeginEditing:")]
		partial void textFieldDidBeginEditing (MonoTouch.Foundation.NSObject sender);

		[Action ("textFieldDidEndEditing:")]
		partial void textFieldDidEndEditing (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_loginButton != null) {
				_loginButton.Dispose ();
				_loginButton = null;
			}

			if (_usernameField != null) {
				_usernameField.Dispose ();
				_usernameField = null;
			}

			if (_passwordField != null) {
				_passwordField.Dispose ();
				_passwordField = null;
			}
		}
	}
}
