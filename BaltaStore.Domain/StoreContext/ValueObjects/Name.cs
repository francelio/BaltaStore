﻿using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
	public class Name : Notifiable
	{
		public Name(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;

			AddNotifications(new ValidationContract()
			.Requires()
			.HasMinLen(FirstName, 3, "FistName", "O nome deve conter pelo menos 3 caracteres")
			.HasMinLen(FirstName, 40, "FistName", "O nome deve conter no maxímo 40 caracteres")
			.HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
			.HasMinLen(LastName, 40, "LastName", "O sobrenome deve conter  no maxímo 40 caracteres")
			);

		}

		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
		
	}
}
