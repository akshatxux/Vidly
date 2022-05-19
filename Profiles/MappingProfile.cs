using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Customer, CustomerDto>();
            //});

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
