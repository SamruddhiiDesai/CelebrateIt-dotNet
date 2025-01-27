using CelebrateIt.Data;
using CelebrateIt.DTOs.UserDTO;
using CelebrateIt.Mapper;
using CelebrateIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CelebrateIt.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using CelebrateIt.Exceptions;

namespace CelebrateIt.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        CelebrateItContext _context;
        
        public AuthRepository(CelebrateItContext context)
        {
            _context = context;

            
        }
        public bool AddUser(Users users)
        {
            try
            {
                using (_context = new CelebrateItContext())
                {
                     
                    _context.Users.Add(users);
                    _context.SaveChanges();
                    return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
            
            
        }

        public Users AuthUserDetails(string email, string password)
        {
            Users user = _context.Users.SingleOrDefault(s => s.Email == email);

            if (user != null)
            {
                // built-in utility class provided by ASP.NET Core for hashing and verifying passwords securely
                var passwordHasher = new PasswordHasher<Users>();
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (result == PasswordVerificationResult.Success)
                {
                    return user;
                }
                else
                {
                    throw new InvalidCredentials("Invalid Password !!!");
                }
            }
            else
            {
                throw new InvalidCredentials("Invalid Email !!!");
            }
        }


        public Users AuthUserDetails(ReqUserLoginDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
