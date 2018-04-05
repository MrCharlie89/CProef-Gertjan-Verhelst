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
    [Table("users")]
    public class Users : BaseEntity<Guid>
    {
        [Column("user_id")]
        public override Guid Id { get; set; }

        [Required]
        [Column("first_name")]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}".Trim();

            }
        }

        [Column("user_name")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        [Display(Name = "User name")]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        [Column("encrypted_pwd")]
        [StringLength(255)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Column("pwd_salt")]
        [StringLength(255)]
        public string Salt { get; set; }

        [Required]
        [Column("email")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public override bool IsNew()
        {
            return Id == Guid.Empty;
        }

    }
}
