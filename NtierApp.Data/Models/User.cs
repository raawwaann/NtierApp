using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Data
{
    public class User
    {
        public string username { get; set; } = string.Empty; 
        public string passwordHash { get; set; } = string.Empty;
    }
}
