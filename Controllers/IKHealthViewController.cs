using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace IKHealth
{
	public partial class IKHealthViewController : UIViewController
	{
		private const string LoginSegueName = "loginSegue";
		
		private SizeF _keyboardSize;
		private UITextField _activeField = null;
				
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public IKHealthViewController (IntPtr handle) : base(handle)
		{	
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		#region View lifecycle
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Release any retained subviews of the main view.
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardWillShow);	
						
			_loginButton.TouchUpInside += OnLoginTouchUpInside;
			
			_usernameField.Text = string.Empty;
			
			_passwordField.Text = string.Empty;
			_passwordField.SegueName = LoginSegueName;
			_passwordField.ViewController = this;
			_passwordField.CanReturn = () => 
			{
				return Login();
			};
		}
		
		public override void ViewDidAppear (bool animated)
		{		
			base.ViewDidAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			
			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillShowNotification, null);

			if (_activeField != null)
				_activeField.ResignFirstResponder();			
			
			_loginButton.TouchUpInside -= OnLoginTouchUpInside;			
		}
		
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
		
		#endregion
		
		private bool Login()
		{
			return !string.IsNullOrEmpty(_usernameField.Text) && !string.IsNullOrEmpty(_passwordField.Text);
		}
		
		private void MoveView(bool moveUp)
		{
			UIView.BeginAnimations(null, IntPtr.Zero);
			UIView.SetAnimationDuration(0.5);
			
			RectangleF rect = View.Frame;
			
		    if (moveUp)
		    {
		        rect.Y -= _keyboardSize.Height;
		        rect.Size.Height += _keyboardSize.Height;
		    }
		    else
		    {
		        rect.Y += _keyboardSize.Height;
		        rect.Size.Height -= _keyboardSize.Height;
		    }
			
			View.Frame = rect;
			
			UIView.CommitAnimations();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
		
		protected void OnKeyboardWillShow(NSNotification notification)
		{			
			_keyboardSize = notification.Name == UIKeyboard.WillHideNotification ? Size.Empty 
								: ((NSValue)notification.UserInfo.ObjectForKey(UIKeyboard.FrameEndUserInfoKey)).RectangleFValue.Size;
							    			
			if (notification.Name == UIKeyboard.WillShowNotification)
			{
				if ( View.Frame.Y >= 0 )
					MoveView(true);	
			}
			else if(notification.Name == UIKeyboard.WillHideNotification)
			{
				if ( View.Frame.Y < 0 )
					MoveView(false);
			}				
		}
			
		protected void OnLoginTouchUpInside(object sender, EventArgs args)
		{
			if (_activeField != null)
				_activeField.ResignFirstResponder();			
		}
		
		partial void textFieldDidBeginEditing (MonoTouch.Foundation.NSObject sender)
		{
			_activeField = sender as UITextField;
		}
		
		partial void textFieldDidEndEditing (MonoTouch.Foundation.NSObject sender)
		{
			_activeField = null;
			
			//TODO: Check if keyboard is still visible, otherwise need to restore view.
		}				
	}
}
