using System.Collections.Generic;

namespace Identity.Model
{
    public class ExtendedUser
    {
        public string Id {get;set;}

        public string Name {get;set;}

        public string Username {get;set;}

        public string Password {get;set;}

        public string Email {get;set;}

        public List<string> Roles {get;set;}
    }
}