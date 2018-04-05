using Syntra.VDOAP.CProef.Ecommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.Ecommerce.LIB.Entities
{
    [Table("localize_products")]
    public class Localize_Product 
    {
        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Column("descr")]
        public string Description { get; set; }
       

        [Column("color")]
        public string Color { get; set; }

        [Column("material")]
        public string Material { get; set; }

       
    }
}
