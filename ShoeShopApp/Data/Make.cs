using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Data
{
    public class Make : BaseDomainEntity
    {
        [Display(Name="Make")]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<ProductModel> ProductModels { get; set; }
    }
}
