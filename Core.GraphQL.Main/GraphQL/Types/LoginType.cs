using Core.Domain.Dto;
using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Types
{
    public class LoginType : ObjectGraphType<Login>
    {
        public LoginType()
        {
            Name = "LoginType";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Username)} of {nameof(Login)}");
            Field(x => x.Email, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Email)} of {nameof(Login)}");
            Field(x => x.Cellphone, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Cellphone)} of {nameof(Login)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Password)} of {nameof(Login)}");
            Field(x => x.Code, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(Login.Code)} of {nameof(Login)}");
        }
    }
}
