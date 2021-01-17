using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stock_info_seeker_api.Model
{
    public class Occurence
    {
        public int Id { get; set; }
        [Display(Name = "Zdarzenie")]
        public string Event { get; set; }
        public string Url { get; set; }
    }
}
