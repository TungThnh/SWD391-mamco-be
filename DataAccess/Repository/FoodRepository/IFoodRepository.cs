using BusinessObject.ResponseModel.FoodResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.FoodRepository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<ListFoodResponse>> GetFoods();
        Task<IEnumerable<ListFoodResponse>> SearchFoods(string text);
    }
}
