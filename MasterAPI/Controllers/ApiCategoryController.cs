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
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
                    context.Categories.Add(form);
                    await context.SaveChangesAsync();
                    await trans.CommitAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Success add Data!",
                        status = true,
                    };

					
                }
                catch (Exception ex)
                {
					await trans.RollbackAsync(); 
                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Failed add Data!" + ex.Message,
                        status = false,
                    };
                }

            }

            
            

			
		}


		[HttpPost]
		public async Task<ApiResponseObj> Update()
		{
            using (var trans = context.Database.BeginTransaction())
            {
				try
				{
                    Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
                    var getData = await context.Categories.Where(s => s.Id == form.Id).FirstOrDefaultAsync();
                    getData.Name = form.Name;
                    getData.Value = form.Value;
                    context.Categories.Update(getData);
                    await context.SaveChangesAsync();
                    await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Success update Data!",
                        status = true,
                    };
                }
				catch (Exception ex)
				{
                    await trans.RollbackAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Failed update Data!" + ex.Message,
                        status = false,
                    };
                }
            
            }
              
		}

		[HttpPost]
		public async Task<ApiResponseObj> Delete()
		{

            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Category form = HttpContext.Request.ReadFromJsonAsync<Category>().Result;
                    var getData = await context.Categories.Where(s => s.Id == form.Id).FirstOrDefaultAsync();
                    context.Categories.Remove(getData);
                    await context.SaveChangesAsync();
                    await trans.CommitAsync();

                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Success delete Data!",
                        status = true,
                    };

                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Categories.ToList(),
                        message = "Failed delete Data!" + ex.Message,
                        status = false,
                    };
                }
            
            
            }
              
		}

	}
}
