using BusinessObject.DataAccess;
using BusinessObject.ResponseModel.FoodResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.FoodRepository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly mamcungappContext dbContext;

        public FoodRepository(mamcungappContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ListFoodResponse>> GetFoods()
        {
            var food = await dbContext.Foods.ToListAsync();
            IEnumerable<ListFoodResponse> result = food.Select(
                x =>
                {
                    return new ListFoodResponse()
                    {
                        Id = x.FoodId,
                        Name = x.Name,
                        Price = x.Price,
                        Status=x.Status
                    };
                }
                ).ToList();
            return result;
        }

        public async Task<IEnumerable<ListFoodResponse>> SearchFoods(string text)
        {
            
            var food = await dbContext.Foods.ToListAsync(); 
            IEnumerable<ListFoodResponse> temp = food.Select(
                x =>
                {
                    return new ListFoodResponse()
                    {
                        Id = x.FoodId,
                        Name = x.Name,
                        Price = x.Price,
                        Status = x.Status
                    };
                }
                ).ToList();
            IEnumerable<ListFoodResponse> result = temp.Where(el => el.Id.ToString().Equals(text)                                                                  
                                    || el.Price.ToString().Replace(".0000", "").Equals(text)
                                    || el.Price.ToString().Equals(text)
                                    || el.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
            
            );
            return result;
        }
    }
}
