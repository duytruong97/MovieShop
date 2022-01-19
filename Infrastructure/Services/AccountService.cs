using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Register(UserRegisterRequestModel model)
        {
            // check if user has not entered already registered email
            var user = await _userRepository.GetUserByEmail(model.Email);
            if(user != null)
            {
                throw new Exception("Email already in used, please login");
            }
            // register the user with hash and salt
            // create a unique salt

            var salt = GetRandomSalt();

            // generate hash with salt

            var hashedPassword = GetHashedPassword(model.Password, salt);
            // save the user

            var newUser = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = model.DateOfBirth,
            };

            

            var dbCreatedUser = await _userRepository.Add(newUser);

            if(dbCreatedUser.Id > 1)
            {
                return true;
            }
            return false;

        }

        public async Task<UserLoginResponseModel> Validate(string Email, string Password)
        {
            var user = await _userRepository.GetUserByEmail(Email);
            if(user == null)
            {
                throw new Exception("Email does not exist");
            }

            var hashedPassword = GetHashedPassword(Password, user.Salt);
            if(hashedPassword == user.HashedPassword)
            {
                var dbUser = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth.GetValueOrDefault(),
                    FirstName = user.FirstName,
                    LastName= user.LastName,

                };
                return dbUser;
            }
            return null;

        }



        private String GetRandomSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);

        }

        private String GetHashedPassword(String password, String salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
