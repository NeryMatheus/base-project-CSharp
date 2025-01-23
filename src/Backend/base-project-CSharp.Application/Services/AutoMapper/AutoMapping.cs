using AutoMapper;
using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Domain.Entities;

namespace base_project_CSharp.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
