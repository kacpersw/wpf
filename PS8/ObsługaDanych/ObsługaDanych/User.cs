using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObsługaDanych
{
    class User : IDataErrorInfo
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? age { get; set; }
        public decimal? salary { get; set; }
        public User(string name, string surname, string email, string password, int age, decimal salary)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.age = age;
            this.salary = salary;
        }
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "password")
                {
                    if (password.Length < 6)
                        return "Hasło musi być dłuższe niż 5 znaków.";
                }
                if (columnName == "name")
                {
                    if (name.Length == 0)
                        return "Imię jest wymagane.";
                }
                if (columnName == "surname")
                {
                    if (surname.Length == 0)
                        return "Nazwisko jest wymagane.";
                }
                if (columnName == "salary")
                {
                    if (salary <= 0)
                        return "Pensja musi być większa niż 0.";
                }
                if (columnName == "age")
                {
                    if (age <= 0)
                        return "Wiek musi być większy od 0.";
                }
                if (columnName == "email")
                {
                    bool isEmail;
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        isEmail = true;
                    }
                    catch
                    {
                        isEmail = false;
                    }
                    if(isEmail == false)
                        return "To nie jest adres email.";
                }
                return null;
            }
        }
    }
}
