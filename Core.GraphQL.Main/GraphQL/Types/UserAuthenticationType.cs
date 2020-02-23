using Core.Domain.Models;
using Core.Domain.Models.Security;
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
            //Field(x => x.JwtToken, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.JwtToken)} of {nameof(UserAuthentication)}");
            //Field(x => x.User, type: typeof(NonNullGraphType<UserType>)).Description($"{nameof(UserAuthentication.User)} of {nameof(UserAuthentication)}");
        }
    }
}
