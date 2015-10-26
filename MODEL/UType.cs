using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class UType
    {
        public UType() { }
        public UType(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
