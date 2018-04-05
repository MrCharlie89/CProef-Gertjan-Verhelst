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
    public class Language : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }

        [Column("languagename")]
        [Required(ErrorMessage = "The Language name is required")]
        public string LanguageName { get; set; }

        [Column("iso")]
        [Required(ErrorMessage = "The ISO for the language is required")]
        public string ISO { get; set; }

        [Column("local name")]
        public string LocalName { get; set; }

        public virtual ICollection<Localize_ProductCategory> Localize_ProductCategories { get; set; }
        public virtual ICollection<Localize_Product> Localize_Product { get; set; }


        public override bool IsNew()
        {
            throw new NotImplementedException();
        }
    }
}
