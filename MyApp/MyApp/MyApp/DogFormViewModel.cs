using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class DogFormViewModel
    {
        public DogFormViewModel()
        {
            Name = "enter name";
        }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
    }
}
