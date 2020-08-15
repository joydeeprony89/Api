using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.DomainObjects
{
    [Table("Category", Schema = "dbo")]
    public class Category : DomainObject<long>
    {
        public string CategoryName { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
