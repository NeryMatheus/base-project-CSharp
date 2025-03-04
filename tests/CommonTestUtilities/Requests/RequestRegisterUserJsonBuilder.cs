﻿using base_project_CSharp.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build(int passwordLength = 10)
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(user => user.Password, (f) => f.Internet.Password(passwordLength));
        }
    }
}
