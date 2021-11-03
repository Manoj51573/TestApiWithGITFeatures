using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebprojectWithGItHub.Models.Helpers
{
    public class Employee
    {
        private int _id;
        private string _department;
        private string _email;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
    public class Product
    {
        public string Title { get; set; }
    }
}
