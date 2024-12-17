using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using PokemonGame.Architecture.Repository;
using PokemonGame.Data;

namespace PokemonGame.Architecture.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly User _user;

        public UserService()
        {
            _userRepository = new UserRepository();
            _user = new User();
        }

        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public bool CreateUserDB(string name, string email,  string password)
        {
            var hashedPassword = HashPassword(password);

            _user.Name = name;
            _user.Email = email;
            _user.Password = hashedPassword;
            _user.IdRol = 2;

            return _userRepository.CreateUser(_user);
        }

        public User LoginUserDB(string email, string password)
        {
            var hashedPassword = HashPassword(password);

            var userEmail = _user.Email = email;
            var userPassword = _user.Password = hashedPassword;

            return _userRepository.LoginUser(userEmail, userPassword);
        }

        public IEnumerable<User> GetUsersDB(int userId)
        {
            var users = _userRepository.GetUsers(userId);

            return users;
        }
    }
}
