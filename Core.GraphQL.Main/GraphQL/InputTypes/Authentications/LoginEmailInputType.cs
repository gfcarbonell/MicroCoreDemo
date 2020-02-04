using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginEmailInputType : InputObjectGraphType<UserAuthentication>
    {
        public LoginEmailInputType()
        {
            Name = "LoginEmailInputType";
            Field(x => x.Email, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Email)} of {nameof(UserAuthentication)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Password)} of {nameof(UserAuthentication)}");
        }
    }
}
