using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App
{
    public class Users
    {
        public string username;
        public string password;
        public int id;
        public string[]? notes;

        private static int lastAssignedId = 0;
        public Users(string username, string password, string[]? notes = null)
        {
            this.username = username;
            this.password = password;
            this.id = ++lastAssignedId;
            this.notes = notes;
        }
    }
}
