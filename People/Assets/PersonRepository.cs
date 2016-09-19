﻿using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;
using System.Threading.Tasks;

namespace People
{
	public class PersonRepository
	{
		public string StatusMessage { get; set; }
		private SQLiteAsyncConnection conn;
		public PersonRepository(string dbPath)
		{
			conn = new SQLiteAsyncConnection(dbPath);
			conn.CreateTableAsync<Person>().Wait();
		}

		public async Task AddNewPersonAsync(string name)
		{
			try
			{
				//ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid Name Required");

				//insert new dude
				var result = await conn.InsertAsync(new Person { Name = name });
				StatusMessage = string.Format("{0} record(s) added, Name: {1}", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}
		}

		public async Task<List<Person>> GetAllPeopleAsync()
		{
			return await conn.Table<Person>().ToListAsync();
		}
	}
}
