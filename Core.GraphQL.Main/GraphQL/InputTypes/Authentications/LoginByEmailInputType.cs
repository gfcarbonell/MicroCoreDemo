using Core.Domain.Models;
using Core.Domain.Security;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginByEmailInputType : InputObjectGraphType<Login>
    {
        public LoginByEmailInputType()
        {
            Name = "LoginByEmailInputType";
            Field(x => x.Email, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Email)} of {nameof(Login)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Password)} of {nameof(Login)}");
        }
    }
}
