using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WiazanieDanych
{
    class Data 
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public double? howMuch { get; set; }
        public string region { get; set; }
        public int value { get; set; }
        public bool details { get; set; }
        public Data(string name, bool details, string region)
        {
            this.name = name;
            this.details = details;
            this.region = region;
        }
        public Data(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public Data(string name, string surname, string email, double howMuch, string region, int value, bool details)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.howMuch = howMuch;
            this.region = region;
            this.value = value;
            this.details = details;
        }
        public override string ToString()
        {
            return surname;
        }
    }
}
