using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Types
{
    public class UserAuthenticationType : ObjectGraphType<UserAuthentication>
    {
        public UserAuthenticationType()
        {
            Name = "Auth";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{0} of {nameof(UserAuthentication)}");
            Field(x => x.Email, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{0} of {nameof(UserAuthentication)}");
            Field(x => x.Cellphone, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{0} of {nameof(UserAuthentication)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{0} of {nameof(UserAuthentication)}");
        }
    }
}
