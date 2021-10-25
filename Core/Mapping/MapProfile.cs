using Core.Dtos;
using AutoMapper;
using Infrastructure.Data.Entities;

namespace Core.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Patient, PatientsDto>().ReverseMap();
        }
    }
}
