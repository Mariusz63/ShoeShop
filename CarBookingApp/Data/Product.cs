using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Data
{
    public class Product : BaseDomainEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Range(0, 100)]
        [Display(Name = "Size")]
        public decimal Size { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Make")]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        [Display(Name = "Type")]
        public int? TypeId { get; set; }
        public virtual Type Type { get; set; }

        [Display(Name = "Product Model")]
        public int? ProductModelId { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
