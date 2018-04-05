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
    public class Localize_ProductCategory 
    {

        [Column ("category ID")]
        public int Category_ID { get; set; }

        [Column ("language ID")]
        public int Language_ID { get; set; }

        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Column("descr")]
        public string Description { get; set; }

        
    }
}
