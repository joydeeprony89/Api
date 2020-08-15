using Api.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businesss
{
    public interface IItemService
    {
        Task<List<Item>> Get(int pageNo, int pageSize, string itemName);
        Task<bool> Delete(string categoryName);
    }
}
