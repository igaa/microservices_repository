using MasterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Model.APP;
using Web.Model.APP.Master;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Master.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiCategoryController : ControllerBase
    {
        MasterContext context = new MasterContext();

        [HttpGet]
        public ApiResponseObj Get()
        {
            return new ApiResponseObj()
            {
                data = context.Categories.ToList(), 
                message = "Success Get Data!", 
                status = true, 
            };
        }

		[HttpGet]
		public ApiResponseObj GetBy(int id)
		{
			return new ApiResponseObj()
			{
				data = context.Categories.Where(s => s.Id == id).FirstOrDefault(),
				message = "Success Get Data!",
				status = true,
			};
		}

		// POST api/<ApiCategoryController>
		[HttpPost]
        public async Task<ApiResponseObj> Post()
        {
			try
			{
                Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
                context.Categories.Add(form);
                await context.SaveChangesAsync();
                return new ApiResponseObj()
                {
                    data = context.Categories.ToList(),
                    message = "Success add Data!",
                    status = true,
                };
            }
			catch (Exception ex)
			{
                return new ApiResponseObj()
                {
                    data = context.Categories.ToList(),
                    message = "Failed add Data!" + ex.Message,
                    status = true,
                };
            }
            

			
		}


		[HttpPost]
		public async Task<ApiResponseObj> Update()
		{
			Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
			var getData = await context.Categories.Where(s => s.Id == form.Id).FirstOrDefaultAsync();
			getData.Name = form.Name;
			getData.Value = form.Value; 
			context.Categories.Update(getData);
			await context.SaveChangesAsync();

			return new ApiResponseObj()
			{
				data = context.Categories.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

		[HttpPost]
		public async Task<ApiResponseObj> Delete()
		{
			Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
			var getData = await context.Categories.Where(s => s.Id == form.Id).FirstOrDefaultAsync();
			context.Categories.Remove(getData);
			context.SaveChanges();

			return new ApiResponseObj()
			{
				data = context.Categories.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

	}
}
