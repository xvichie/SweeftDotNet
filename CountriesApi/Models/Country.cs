using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Models
{
    public class Country
    {
        public Name Name { get; set; }

        public string Region { get; set; } = string.Empty;

        public string Subregion { get; set; } = string.Empty;

        public long Population { get; set; }

        public double Area { get; set; }
    }
    public class Name
    {
        public string Common { get; set; } = string.Empty;

        public string Official { get; set; } = string.Empty;
    }
}
