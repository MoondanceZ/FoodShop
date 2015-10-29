using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class PrdReview
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PrdNo { get; set; }
        public string ReviewContebt { get; set; }
        public decimal AssignMark { get; set; }
    }
}
