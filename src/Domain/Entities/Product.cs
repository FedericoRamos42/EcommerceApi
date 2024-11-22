using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; } = string.Empty ;
        public int Stock {  get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
        public Status Status { get; set; } = Status.Active;
        public List<OrderDetail>OrderDetailsList { get; set; } = new List<OrderDetail>();

    }
}
