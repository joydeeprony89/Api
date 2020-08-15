using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.DomainObjects
{
    [Table("SubCategory", Schema = "dbo")]
    public class SubCategory : DomainObject<long>
    {
        public string SubCategoryName { get; set; }
        [ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Item> Items { get; set; }
    }
}
