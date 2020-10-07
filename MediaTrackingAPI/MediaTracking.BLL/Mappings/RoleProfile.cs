using AutoMapper;
using MediaTracking.BLL.DTOs;
using MediaTracking.DAL.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.BLL.Mappings
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
        }
    }
}
