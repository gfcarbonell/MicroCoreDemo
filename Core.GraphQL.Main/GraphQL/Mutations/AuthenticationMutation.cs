using Core.Domain.Models;
using Core.GraphQL.Main.GraphQL.InputTypes.Authentications;
using Core.GraphQL.Main.GraphQL.Types;
using Core.Service.Contract.IServices;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.GraphQL.Mutations
{
    public class AuthenticationMutation : ObjectGraphType
    {
        public AuthenticationMutation(IUserAuthenticationService _userAuthenticationService)
        {
            Name = "AuthMutation";

            FieldAsync<UserAuthenticationType>(
                name: "loginByUsername",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByUserNameInputType>> { Name = "login" }),

                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");
                    var auth = await _userAuthenticationService.LoginByUsernameAsync(login);
                    return auth;
                });

            FieldAsync<UserAuthenticationType>(
                name: "loginByEmail",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByEmailInputType>> { Name = "login" }),
                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");
                    var auth = await _userAuthenticationService.LoginByUsernameAsync(login);
                    return auth;
                });

            FieldAsync<UserAuthenticationType>(
                name: "loginByCellphone",
                arguments: new QueryArguments(
                           new QueryArgument<NonNullGraphType<LoginByCellphoneInputType>> { Name = "login" }),
                resolve: async contextAsync =>
                {
                    var login = contextAsync.GetArgument<Login>("login");
                    var auth = await _userAuthenticationService.LoginByUsernameAsync(login);
                    return auth;
                });
        }
    }
}
