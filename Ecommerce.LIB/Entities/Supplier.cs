using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.Ecommerce.LIB.Entities
{
    [Table("supplier")]
    public class Supplier : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }


        [Column("vatnumber")]
        [Required(ErrorMessage = "A  VAT number is required")]
        [StringLength(20, ErrorMessage = " the VAT number can maximum have 20 numbers")]
        public string VATNumber { get; set; }

        [Column("suppliername")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Suppliername { get; set; }

        [Column("streetname_and_number")]        
        [Required(ErrorMessage = "the streetname and number is required")]
        public string StreetnameAndNumber { get; set; }

        [Column("city")]
        [Required(ErrorMessage =" the city name is required")]
        public string City { get; set; }
       
        [Column("postalcode")]
        [Required(ErrorMessage = "the Postalcode is required")]
        public string Postalcode { get; set; }

        [Column("phonenumber")]
        [StringLength(15, ErrorMessage = "The maximumlength of a phonenumber is 15 characters")]
        [Required(ErrorMessage = "The phonenumber is required")]
        public string Phonenumber { get; set; }

        [Column("emailadress")]
        [Required(ErrorMessage = "An emailadress is required")]
        public string Emailadress { get; set; }

        [Column("name_contact")]
        public string NameContact { get; set; }

        [Column("contact_telephone_number")]
        public string ContactTelephoneNumber { get; set; }

        [Column("emailadress_contact")]
        public string EmailadressContact { get; set; }



        public override bool IsNew()
        {
            return this.Id == 0;
        }
    }
}
