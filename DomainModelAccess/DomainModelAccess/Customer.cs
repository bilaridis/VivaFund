using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelAccess.DomainModelAccess
{
    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

       // [ForeignKey("ProductId")]
        public virtual ICollection<Product> Products { get; set; }

    }
}