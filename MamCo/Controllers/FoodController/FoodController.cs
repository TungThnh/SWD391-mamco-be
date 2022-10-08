using BusinessObject.ResponseModel.FoodResponse;
using DataAccess.Repository.FoodRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamCo.Controllers.FoodController
{
    [Route("api/Food")]
    [ApiController]

    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository foodRepository;
        public FoodController(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }
       [HttpGet]
       [Route("GetFoods")]
        public async Task<ActionResult> GetFoods()
        {
            try
            {
                return Ok(await foodRepository.GetFoods());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpGet]
        [Route("SearchFoods")]
        public async Task<ActionResult> SearchFood(string text)
        {
            try
            {
                var result = await foodRepository.SearchFoods(text);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    "Not thing here.");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

    }
}
