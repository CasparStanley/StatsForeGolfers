using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class UserRepository
    {
        private static UserRepository _instance;

        private List<User> users = new List<User>();

        private UserRepository()
        {
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public User Get()
        {
            /* Fetches first user
             * Refactor to more specific fetching of users.
             */

            if (users.Count > 0)
            {
                return users[0];
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
