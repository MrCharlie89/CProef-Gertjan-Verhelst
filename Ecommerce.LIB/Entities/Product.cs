using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.Ecommerce.LIB.Entities
{
    [Table("products")]
    public class Product : BaseEntity<int>
    {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("product_code")]
        [StringLength(50, ErrorMessage = "The product code can maximum have 50 characters.")]
        [Required(ErrorMessage = "The product code is required.")]
        public string ProductCode { get; set; }

        [Column("unit_price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999999999, ErrorMessage = "Price must be greater than 0,00")]
        [DisplayName("Unit price (€)")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal UnitPrice { get; set; }

        [Column("Current_Stock")]
        [Required(ErrorMessage = "the current stock is required")]        
        public int CurrentStock { get; set; }

        // [ForeignKey("PriceByTypeId")]
        //  public virtual UnitPriceType PriceByType { get; set; }

        [Column("is_active")]
        [DisplayName("Is active?")]
        [Required(ErrorMessage = "The is active is required")]
        public bool IsActive { get; set; }



        public ProductCategory ProductCategory { get; set; }

        public virtual ICollection<Localize_Product> Localize_Product { get; set; }


        public override bool IsNew()
        {
            return this.Id == 0;
        }
    }
}
