using AutoMapper;
using blogApi.Data.Dtos;
using blogApi.models;

namespace blogApi.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<CreatePostDto, Post>();
        CreateMap<UpdatePostDto, Post>();
        CreateMap<Post, UpdatePostDto>();
        CreateMap<ReadPostDto, Post>();
    }
}