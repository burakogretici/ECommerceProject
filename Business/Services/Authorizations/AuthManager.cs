﻿using Business.Constants;
using Business.Helpers.Jwt;
using Business.Services.Users;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Dtos.Users;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Services.Authorizations
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IDataResult<UserDto>> Register(UserForRegister userForRegister, string password)
        {
            var userToCheck = UserExits(userForRegister.Email);
            if (userToCheck != null && !userToCheck.Success)
            {
                return new ErrorDataResult<UserDto>(userToCheck.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);
            var user = new UserDto
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };

            await _userService.AddAsync(user);
            return new SuccessDataResult<UserDto>(user, Messages.UserRegistered);
        }

        public async Task<IDataResult<UserDto>> Login(UserForLogin userForLogin)
        {
            var userToCheck = await _userService.GetByMail(userForLogin.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<UserDto>(userToCheck.Message);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<UserDto>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserDto>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExits(string email)
        {
            var userExists = _userService.GetByMail(email).Result.Data;
            if (userExists != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }


        public async Task<IDataResult<AccessToken>> CreateAccessToken(UserDto userDto)
        {
            var claims = await _userService.GetClaims(userDto);

            var accessToken = _tokenHelper.CreateToken(userDto, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
