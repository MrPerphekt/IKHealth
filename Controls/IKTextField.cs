using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace IKHealth
{
	[Register("IKTextField")]
	partial class IKTextField : UITextField
	{
		private UITextField _nextField;
		//private UIReturnKeyType _returnKeyType;
		
		public Func<bool> CanReturn
		{
			get;
			set;
		}		
		
		[Outlet("NextField")]
		public UITextField NextField 
		{ 
			get
			{
				return _nextField;
			}
			set
			{
				if ( value != null )
					_nextField = value;
				
				this.ReturnKeyType = UIReturnKeyType.Next;	
			}
		}
		
		/*
		public override UIReturnKeyType ReturnKeyType
		{
			get
			{
				if (_returnKeyType == UIReturnKeyType.Go )
					return CanReturn == null || CanReturn() ? _returnKeyType : UIReturnKeyType.Default;
				
				return _returnKeyType;
			}
			set
			{
				_returnKeyType = value;
			}
		}
		*/
		
		public string SegueName
		{
			get;
			set;
		}
		
		public UIViewController ViewController
		{
			get;
			set;
		}
		
		public IKTextField ()
		{
			ShouldReturn = TextFieldShouldReturn;
		}
		
		public IKTextField(IntPtr handle)
			: base(handle)
		{
			ShouldReturn = TextFieldShouldReturn;
		}

		protected bool TextFieldShouldReturn(UITextField textField)
		{
			if ( textField == null )
				return false;
			
			if (!textField.ResignFirstResponder())
				return false;
		
			if (textField is IKTextField)
			{
				var nextField = (textField as IKTextField).NextField;
			
				if (nextField != null)
					nextField.BecomeFirstResponder();
				
				if (!string.IsNullOrEmpty(SegueName)
				    && ViewController != null
				    && (CanReturn == null || CanReturn()))
				{
					ViewController.PerformSegue(SegueName, this);
				}
				
				return true;
			}
			
			return true;
		}
	}
}

