using AutoMapper;
using OnlineQuiz.Application.DTOs;
using OnlineQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Application.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SignUpDto, AppUser>();
                
        }
    }
}
