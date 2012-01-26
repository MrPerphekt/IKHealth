using System;
using System.Collections.ObjectModel;

namespace IKHealth
{
	public static class ClientInterface
	{	
		public static ObservableCollection<string> Patients
		{
			get;
			private set;
		}		
	}
}

