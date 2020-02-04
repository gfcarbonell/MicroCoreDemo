using Core.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.InputTypes.Users
{
    public class AddUserInputType : InputObjectGraphType<User>
    {
        public AddUserInputType()
        {
            Name = "AddUserInputType";
            Field(x => x.Username, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Username)} of {nameof(User)}");
            Field(x => x.Password, type: typeof(NonNullGraphType<StringGraphType>)).Description($"{nameof(UserAuthentication.Password)} of {nameof(UserAuthentication)}");
        }
    }
}
