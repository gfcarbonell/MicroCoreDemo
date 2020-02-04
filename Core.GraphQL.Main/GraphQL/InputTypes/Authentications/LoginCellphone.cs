using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginCellphone : InputObjectGraphType<UserAuthentication>
    {
        public LoginCellphone()
        {
            Name = "LoginInputType";
            Field(x => x.Cellphone, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Cellphone)} of {nameof(UserAuthentication)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Password)} of {nameof(UserAuthentication)}");
        }
    }
}
