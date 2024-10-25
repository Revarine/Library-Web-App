using AutoMapper;
using Library.Application.Common.DTO;
using Library.Domain.Entities;

namespace Library.Application.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorDTO, Author>();
        CreateMap<Author, AuthorDTO>();

        CreateMap<GenreDTO, Genre>();
        CreateMap<Genre, GenreDTO>();

        CreateMap<BookDTO, Book>();
        CreateMap<Book, BookDTO>();

        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>();

        CreateMap<TakenBookDTO, TakenBook>();
        CreateMap<TakenBook, TakenBookDTO>();
    }
}