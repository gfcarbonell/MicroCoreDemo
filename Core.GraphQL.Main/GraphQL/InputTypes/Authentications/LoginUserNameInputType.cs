using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginUsernameInputType : InputObjectGraphType<UserAuthentication>
    {
        public LoginUsernameInputType()
        {
            Name = "LoginInputType";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Username)} of {nameof(UserAuthentication)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Password)} of {nameof(UserAuthentication)}");
        }
    }
}
