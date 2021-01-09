using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stock_info_seeker_api.Model
{
    public class SeekFor
    {
        public int Id { get; set; }
        [Display(Name = "Wyrażenie")]
        [Required(ErrorMessage = "Wymagane")]
        [StringLength(30, MinimumLength = 1)]
        public string Word { get; set; }
    }
}
