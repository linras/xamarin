using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;

namespace MyApp.Models
{
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Try { get; set; }
        public string District { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TimeSpan Time { get; set; }
        //public List<string> People { get; set; }
        public string FilePath { get; set; }
        public bool Status { get; set; }
        public Dog()
        {
        }

    }
}
