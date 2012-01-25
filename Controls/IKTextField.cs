using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace IKHealth
{
	[Register("IKTextField")]
	partial class IKTextField : UITextField
	{
		private UITextField _nextField;
		
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
		
		public IKTextField ()
		{
		}
		
		public IKTextField(IntPtr handle)
			: base(handle)
		{
		}
	}
}

