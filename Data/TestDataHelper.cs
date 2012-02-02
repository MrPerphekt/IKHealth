using System;
using System.IO;

namespace IKHealth
{
	public static class TestDataHelper
	{		
		private static Random _randomIndexGenerator = new Random(128);
		
		private static string[] _firstNames;
		private static string[] _lastNames;
		
		public static bool IsInitialized
		{
			get;
			private set;
		}
		
		public static string GetRandomFirstName()
		{			
			int index = _randomIndexGenerator.Next(1, _firstNames.Length - 1);
			
			return _firstNames[index];
		}
		
		public static string GetRandomLastName()
		{					
			int index = _randomIndexGenerator.Next(1, _lastNames.Length - 1);
			
			return _lastNames[index];
		}		
		
		public static void Initialize()
		{
			_firstNames = File.ReadAllLines("Data/CSV_Database_of_First_Names.csv");			
			_lastNames = File.ReadAllLines("Data/CSV_Database_of_Last_Names.csv");			
			
			IsInitialized = true;
		}
		
		public static void Uninitialize()
		{
			_firstNames = null;
			_lastNames = null;
			
			IsInitialized = false;
		}
	}
}

