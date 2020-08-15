using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.DomainObjects
{
    [Table("Item", Schema = "dbo")]
    public class Item : DomainObject<long>
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        [ForeignKey("SubCategoryId")]
        public long SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
