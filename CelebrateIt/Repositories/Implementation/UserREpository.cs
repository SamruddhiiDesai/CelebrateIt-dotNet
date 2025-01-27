﻿using CelebrateIt.Data;
using CelebrateIt.Models;
using CelebrateIt.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace CelebrateIt.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly CelebrateItContext _context;

        public UserRepository(CelebrateItContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
