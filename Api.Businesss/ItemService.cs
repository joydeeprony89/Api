using Api.Domain.DomainObjects;
using Api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businesss
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext appDbContext;

        public ItemService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> Delete(string categoryName)
        {
            try
            {
                var category = await appDbContext.Categories.Where(item => item.CategoryName == categoryName).Include(i=>i.SubCategories).ThenInclude(i=>i.Items)
                    .FirstOrDefaultAsync();
                if (category != null)
                {
                    appDbContext.SubCategories.RemoveRange(category.SubCategories);
                    foreach(var item in category.SubCategories)
                    {
                        appDbContext.Items.RemoveRange(item.Items);
                    }
                    appDbContext.Categories.Remove(category);
                    await appDbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Item>> Get(int pageNo, int pageSize, string itemName)
        {
            try
            {
                int take = pageSize > 50 ? 10 : pageSize;
                int skip = (pageNo - 1) * take;

                if (string.IsNullOrWhiteSpace(itemName))
                    return await appDbContext.Items
                        .AsNoTracking()
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
                else
                {
                    var result = await appDbContext.Items
                       .AsNoTracking()
                       .Where(item => item.ItemName.Contains(itemName))
                       .Skip(skip)
                       .Take(take)
                       .ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
