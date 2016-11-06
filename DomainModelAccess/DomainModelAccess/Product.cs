using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelAccess.DomainModelAccess
{
    public class Product
    {
        public Product()
        {
            
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Prize { get; set; }
        public bool IsActive { get; set; }

      
        public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}