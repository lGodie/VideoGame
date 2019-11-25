using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGame.Data.Entities;
using VideoGame.Helpers;

namespace VideoGame.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var productorInterno = await CheckUserAsync( "Diego", "Z", "Productorinterno@hotmail.com", "350 634 2747", "productorInterno");
            var Desarrollador = await CheckUserAsync( "Alejandro", "D", "Desarrollador@gmail.com", "3106796878", "Desarrollador");
            await CheckProductorinternoAsync(productorInterno);
            await CheckDesarrolladorAsync(Desarrollador);
        }

        

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Productorinterno");
            await _userHelper.CheckRoleAsync("Desarrollador");
        }

        private async Task CheckProductorinternoAsync(User user)
        {
            if (!_context.productorInternos.Any())
            {
                _context.productorInternos.Add(new productorInterno { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDesarrolladorAsync(User user)
        {
            if (!_context.Desarrolladores.Any())
            {
                _context.Desarrolladores.Add(new Desarrollador { User = user });
                await _context.SaveChangesAsync();
            }
        }


        private async Task<User> CheckUserAsync(
            string firstName,
            string lastName,
            string email,
            string phone,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Nombres = firstName,
                    Apellidos = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

    }
}
