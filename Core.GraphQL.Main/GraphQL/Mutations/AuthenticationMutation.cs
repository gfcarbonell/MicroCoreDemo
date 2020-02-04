using Core.Domain.Models;
using Core.GraphQL.Main.GraphQL.InputTypes.Authentications;
using Core.GraphQL.Main.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Mutations
{
    public class AuthenticationMutation : ObjectGraphType
    {
        public AuthenticationMutation()
        {
            Name = "AuthMutation";

            Field<UserAuthenticationType>(
                name: "login",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginUsernameInputType>> { Name = "login" }),
                resolve: context =>
                {
                    var auth = context.GetArgument<UserAuthentication>("login");
                    return auth;
                });
        }
    }
}
