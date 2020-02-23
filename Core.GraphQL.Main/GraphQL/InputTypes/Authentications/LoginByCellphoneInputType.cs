using Core.Domain.Models;
using Core.Domain.Security;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Authentications
{
    public class LoginByCellphoneInputType : InputObjectGraphType<Login>
    {
        public LoginByCellphoneInputType()
        {
            Name = "LoginByCelphoneInputType";
            Field(x => x.Cellphone, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Cellphone)} of {nameof(Login)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Password)} of {nameof(Login)}");
        }
    }
}
