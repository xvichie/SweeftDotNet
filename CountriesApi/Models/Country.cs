using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Models
{
    public class Country
    {
        public NameObject Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
    }
    public class NameObject
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
}
