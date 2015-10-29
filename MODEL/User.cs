using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class User
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string PassWord { get; set; }
        public string Guid { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime RegTime { get; set; }
        public UType UType { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
