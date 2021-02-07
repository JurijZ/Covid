using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.POCOs
{
    public class TypedCase
    {
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string case_code { get; set; }
        public DateTime? confirmation_date { get; set; }
        public string municipality_code { get; set; }
        public string municipality_name { get; set; }
        public string age_bracket { get; set; }
        public string gender { get; set; }
        public int? object_id { get; set; }
    }
}
