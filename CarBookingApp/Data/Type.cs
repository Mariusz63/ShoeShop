using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoeShopApp.Data
{
    public class Type : BaseDomainEntity
    {
        [Display(Name = "Type")]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}