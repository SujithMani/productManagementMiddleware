using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class PageDetailsView
    {
        public int Id { get; set; }
        public string PageKey { get; set; }
        public string PageDescription { get; set; }
    }
}