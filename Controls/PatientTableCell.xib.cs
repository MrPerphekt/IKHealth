using System;
using MonoTouch.UIKit;

namespace IKHealth
{
	public partial class PatientTableCell : UITableViewCell
	{
		private Patient _patient;
		
		public PatientTableCell () : base()
		{
		}
        
        public PatientTableCell(IntPtr handle) : base(handle)
        {
        }
        
        public void SetupCell(Patient patient)
        {
			_patient = patient;
			
			_patientNameLabel.Text = _patient.Name;
			_diagnosisLabel.Text = _patient.DiagnosisDescription;
			_roomNumberLabel.Text = _patient.Room;			
        }		
	}
}

