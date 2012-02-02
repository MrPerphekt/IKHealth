// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace IKHealth
{
	[Register ("PatientTableCell")]
	partial class PatientTableCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel _patientNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _diagnosisLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _roomNumberLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_patientNameLabel != null) {
				_patientNameLabel.Dispose ();
				_patientNameLabel = null;
			}

			if (_diagnosisLabel != null) {
				_diagnosisLabel.Dispose ();
				_diagnosisLabel = null;
			}

			if (_roomNumberLabel != null) {
				_roomNumberLabel.Dispose ();
				_roomNumberLabel = null;
			}
		}
	}
}
