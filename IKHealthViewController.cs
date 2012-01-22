using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;

namespace IKHealth
{
	public partial class IKHealthViewController : UIViewController
	{
		private const int kOFFSET_FOR_KEYBOARD = 60;
		
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
			
			// Any additional setup after loading the view, typically from a nib.
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
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			
			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillShowNotification, null);
		}
		
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
		
		#endregion
		
		private void MoveView(bool moveUp)
		{
			UIView.BeginAnimations(null, IntPtr.Zero);
			UIView.SetAnimationDuration(0.5);
			
			RectangleF rect = View.Frame;
			
		    if (moveUp)
		    {
		        // 1. move the view's origin up so that the text field that will be hidden come above the keyboard 
		        // 2. increase the size of the view so that the area behind the keyboard is covered up.
		        rect.Y -= kOFFSET_FOR_KEYBOARD;
		        rect.Size.Height += kOFFSET_FOR_KEYBOARD;
		    }
		    else
		    {
		        // revert back to the normal state.
		        rect.Y += kOFFSET_FOR_KEYBOARD;
		        rect.Size.Height -= kOFFSET_FOR_KEYBOARD;
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
			if (View.Frame.Y >= 0)
			{
				MoveView(true);	
			}
			else if(View.Frame.Y < 0)
			{
				MoveView(false);
			}
		}
			
		partial void textFieldDidBeginEditing (MonoTouch.Foundation.NSObject sender)
		{
			
		}
	}
}
