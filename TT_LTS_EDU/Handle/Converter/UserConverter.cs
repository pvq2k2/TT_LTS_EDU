﻿using System.Numerics;
using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class UserConverter
    {
        public UserDTO EntityUserToDTO(User user)
        {
            return new UserDTO { 
                FullName = user.FullName,
                Phone = user.Phone,
                Avatar = user.Avatar,
                Email = user.Email,
                Address = user.Address,
            };
        }
    }
}
