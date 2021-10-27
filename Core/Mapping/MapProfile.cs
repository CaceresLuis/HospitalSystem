﻿using Core.Dtos;
using AutoMapper;
using Infrastructure.Data.Entities;

namespace Core.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Nurse, NurseDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Patient, PatientsDto>().ReverseMap();
        }
    }
}
