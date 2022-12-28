using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDal
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
