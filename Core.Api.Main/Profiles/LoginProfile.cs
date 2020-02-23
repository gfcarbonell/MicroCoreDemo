using AutoMapper;
using Core.Api.Main.ViewModels.RequestModel.UserAuthentication;
using Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginByCellphoneViewModelRequest>().ReverseMap();
            CreateMap<Login, LoginByEmailViewModelRequest>().ReverseMap();
            CreateMap<Login, LoginByUsernameViewModelRequest>().ReverseMap();
        }
    }
}
