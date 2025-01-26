using AutoMapper;
using base_project_CSharp.Application.Cryptography;
using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Communication.Responses;
using base_project_CSharp.Domain.Entities;
using base_project_CSharp.Domain.Repositories;
using base_project_CSharp.Domain.Repositories.User;
using base_project_CSharp.Exceptions.ExceptionBase;

namespace base_project_CSharp.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IUserWriteRepositoryOnly _writeOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(
            IUserWriteRepositoryOnly writeOnlyRepository, 
            IMapper mapper, 
            PasswordEncripter passwordEncripter,
            IUnitOfWork unitOfWork
            )
        {
            _writeOnlyRepository = writeOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterUserJson> RegisterUser(RequestRegisterUserJson request)
        {
            Validate(request);

            var user = _mapper.Map<UserEntity>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            await _writeOnlyRepository.Add(user);

            await _unitOfWork.Commit();

            return new ResponseRegisterUserJson
            {
                Name = request.Name,
            };
        }

        public void Validate(RequestRegisterUserJson request) {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false) { 
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
