using AutoMapper;
using ErrorOr;
using FluentValidation;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UserDTO> _validator;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDTO> validator, ISender mediator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<ErrorOr<UserDTO>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(null, request.username, request.email, request.passwordHash, false);
        var userDTO = _mapper.Map<UserDTO>(user);
        var validationResult = await _validator.ValidateAsync(userDTO);

        if (!validationResult.IsValid)
        {
            return Error.Validation("Bad Request: Validation Failure", string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        await _userRepository.CreateAsync(user, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return userDTO;
    }
}