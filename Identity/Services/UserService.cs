using System;
using System.Collections.Generic;
using System.Linq;
using Identity.Model;

namespace Identity.Services
{
    public class UserService
    {
        // some dummy data. Replce this with your user persistence. 
        private readonly List<ExtendedUser> _users = new List<ExtendedUser>
        {
            new ExtendedUser{
                Id = "1",
                Name = "The Administrator",
                Username = "admin",
                Password = "admin",
                Email = "admin@google.com",
                Roles = new List<string> { "ADMIN", "USER" }
            },
            new ExtendedUser{
                Id = "2",
                Name = "The User",
                Username = "user",
                Password = "user",
                Email = "user@google.com",
                Roles = new List<string> { "USER" }
            },
        };
 
        public bool ValidateCredentials(string username, string password)
        {
            var user = this.FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }
 
            return false;
        }
 
        public ExtendedUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public ExtendedUser FindById(string id)
        {
            return _users.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}