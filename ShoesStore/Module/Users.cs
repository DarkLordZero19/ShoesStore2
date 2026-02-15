using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShoesStore.Module
{
    public class Users
    {
        public Users(Guid Id, string userName, string password, RoleType role, DateTime createdDate)
        {
            ID = Id;
            UserName = userName;
            Password = password;
            Role = role;
            CreatedDate = createdDate;
        }

        public Users(string userName, string password, RoleType role)
        {
            ID = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Role = role;
            CreatedDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public enum RoleType
        {
            Client,
            Manager,
            Admin,
            Guest
        }

        public RoleType Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }
}
