using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;

namespace People
{
	public class PersonRepository
	{
		public string StatusMessage { get; set; }

		public PersonRepository(string dbPath)
		{

		}

		public void AddNewPerson(string name)
		{
			int result = 0;
			try
			{
				//ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid Name Required");

				//insert new dude

				StatusMessage = string.Format("{0} record(s) added [Name: {1}", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}
		}

		public List<Person> GetAllPeople()
		{

		}
	}
}
