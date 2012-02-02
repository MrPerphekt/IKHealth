using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace IKHealth
{
	public static class ClientInterface
	{	
		private static ObservableCollection<Patient> _patients;
		
		public static ObservableCollection<Patient> Patients
		{
			get
			{
				if ( _patients == null )
				{
					if ( TestDataHelper.IsInitialized == false )
						TestDataHelper.Initialize();
					
					List<Patient> temp = new List<Patient>();
					
					for ( int i = 100; i <= 150; i++)
					{
						Patient patient = new Patient();
						patient.Name = TestDataHelper.GetRandomFirstName() + " " + TestDataHelper.GetRandomLastName();
						patient.DiagnosisDescription = "Severe Hangover";
						patient.Room = i.ToString();
						
						temp.Add(patient);
					}
					
					_patients = new ObservableCollection<Patient>(temp);
					
					if ( TestDataHelper.IsInitialized == true )
						TestDataHelper.Uninitialize();
				}
				
				return _patients;
			}
		}				
	}
}

