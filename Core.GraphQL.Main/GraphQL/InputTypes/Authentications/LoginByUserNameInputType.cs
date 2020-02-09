using Core.Domain.Dto;
using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginByUsernameInputType : InputObjectGraphType<Login>
    {
        public LoginByUsernameInputType()
        {
            Name = "LoginByUsernameInputType";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Username)} of {nameof(Login)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Password)} of {nameof(Login)}");
        }
    }
}
