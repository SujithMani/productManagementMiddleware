using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class PageDetailsView
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Page Key Required")]
        public string PageKey { get; set; }
        [Required(ErrorMessage = "Page Description Required")]
        public string PageDescription { get; set; }
    }
}