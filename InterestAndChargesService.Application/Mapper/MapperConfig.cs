using AutoMapper;
using InterestAndChargesService.Application.DTO;
using InterestAndChargesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Application.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<InterestAccrualRequestDTO, InterestAccrual>().ReverseMap();
            CreateMap<InterestAccrualResponseDTO, InterestAccrual>().ReverseMap();
            CreateMap<PenaltyResponseDTO, Penalty>().ReverseMap();

        }
    }
}
