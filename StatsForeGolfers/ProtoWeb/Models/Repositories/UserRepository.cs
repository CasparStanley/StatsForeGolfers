using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class UserRepository
    {
        private static UserRepository _instance;

        private User userObject;

        private UserRepository()
        {
        }

        public void Add(User user)
        {
            userObject = user;
        }

        public User Get()
        {
            if (userObject != null)
            {
                return userObject;
            }
            else
            {
                return null;
            }
        }

        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRepository();
                    
                }
                return _instance;
            }
        }
    }
}
