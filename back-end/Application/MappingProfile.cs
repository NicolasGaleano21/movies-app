using Application.Contract.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contract
{
    public class MappingProfile : Profile
    {
        // This class defines a mapping profile for AutoMapper, specifying how to convert domain entities to DTOs.
        public MappingProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(
                    m => m.Actors, // Specifies the destination property in MovieDTO
                    x =>
                        x.MapFrom(ma => // Defines how the property value is obtained
                            ma.MovieActors != null
                                ? ma
                                    .MovieActors.Select(a => new ActorDTO()
                                    {
                                        Name = a.Actor != null ? a.Actor.Name : string.Empty,
                                    })
                                    .ToList()
                                : new List<ActorDTO>()
                        )
                )
                .ForMember(
                    m => m.Genres,
                    x =>
                        x.MapFrom(mg =>
                            mg.MovieGenres != null
                                ? mg
                                    .MovieGenres.Select(g => new GenreDTO()
                                    {
                                        Description =
                                            g.Genre != null ? g.Genre.Description : string.Empty,
                                    })
                                    .ToList()
                                : new List<GenreDTO>()
                        )
                );
        }
    }
}
