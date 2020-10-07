using MediaTracking.BLL.DTOs;
using MediaTracking.DAL.Models.Authentication;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.BLL.Mappings
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, UserDTO>();
        }
    }
}
