using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes
{
    public class UserInputType : InputObjectGraphType<User>
    {
        public UserInputType()
        {
            Name = "UserInputType";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"Username of {nameof(User)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"Password of {nameof(User)}");
            Field(x => x.Nickname, type: typeof(NonNullGraphType<StringGraphType>)).Description($"Nickname of {nameof(User)}");
        }
    }
}
