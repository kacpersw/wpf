using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edycja
{
    class User
    {
        private string name;
        private string surname;
        private string email;

        public User(string _name, string _surname, string _email)
        {
            name = _name;
            surname = _surname;
            email = _email;
        }

        public string showName()
        {
            return name;
        }
        public string showSurname()
        {
            return surname;
        }
        public string showEmail()
        {
            return email;
        }
        public string show()
        {
            return name + " " + surname + " " + email;
        }
        public void changeName(string name)
        {
            this.name = name;
        }
        public void changeSurname(string surname)
        {
            this.surname = surname;
        }
        public void changeEmail(string email)
        {
            this.email = email;
        }
    }
}
