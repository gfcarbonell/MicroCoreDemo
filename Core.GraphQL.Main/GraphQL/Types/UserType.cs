using Core.Domain.Models;
using Core.Domain.Models.Security;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description($"{nameof(User.Id)} of {nameof(User)}");
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(User.Username)} of {nameof(User)}");
            Field(x => x.Nickname, type: typeof(StringGraphType)).Description($"{nameof(User.Nickname)} of {nameof(User)}");
        }
    }
}
