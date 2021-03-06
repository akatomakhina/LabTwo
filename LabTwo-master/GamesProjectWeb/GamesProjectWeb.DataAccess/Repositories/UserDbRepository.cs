﻿using GamesProjectWeb.DataAccess.Common.Models;
using GamesProjectWeb.DataAccess.Common.Repositories;
using GamesProjectWeb.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GamesProjectWeb.DataAccess.Repositories
{
    public class UserDbRepository : IUserRepository
    {
        private GamesProjectContext _context;
        private bool isDisposed = false;

        public UserDbRepository(GamesProjectContext context)
        {
            _context = context;
        }

        public async Task<DbUser> AddUserAsync(DbUser user)
        {
            if (ReferenceEquals(user, null))
            {
                throw new ArgumentNullException(nameof(user));
            }

            var addedItem = _context.Users.Add(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return addedItem;
        }

        public async Task<DbUser> DeleteUserAsync(DbUser user)
        {
            if (ReferenceEquals(user, null))
            {
                throw new ArgumentNullException(nameof(user));
            }

            var deletedItem = _context.Users.Remove(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return deletedItem;
        }

        public async Task<IEnumerable<DbUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<DbUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // If need dispose something
                }

                isDisposed = true;
                _context?.Dispose();
                _context = null;
            }
        }

        ~UserDbRepository()
        {
            Dispose(false);
        }
    }
}
