using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class InvokerProductUpdate
    {
        public int Id { get; set; }
        [ForeignKey("AdminDetails")]
        public int AdminUserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual AdminDetailsVIew AdminDetails { get; set; }
        public virtual Product Product { get; set; }
    }
}