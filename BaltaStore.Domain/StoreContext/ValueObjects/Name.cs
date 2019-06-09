using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
	public class Name
	{
		public Name(string fistName,string lastName)
		{
			FistName = fistName;
			LastName = lastName;
		}
		public string FistName { get; private set; }
		public string LastName { get; private set; }
		//sobrecrevendo o metodo Tostring caso contrario return namespace+custumer
		public override string ToString()
		{
			return $"{FistName} {LastName}";
		}
	}
}
