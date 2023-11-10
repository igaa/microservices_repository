using Microsoft.AspNetCore.Mvc;
using Web.Model.APP;
using Web.Model.APP.Blogging;
using BlogingAPI;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Bloging.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiPostController : ControllerBase
    {
        BlogingContext context = new BlogingContext();

        [HttpGet]
        public ApiResponseObj Get()
        {
            return new ApiResponseObj()
            {
                data = context.Posts.ToList(), 
                message = "Success Get Data!", 
                status = true, 
            };
        }

		[HttpGet]
		public ApiResponseObj GetBy(int id)
		{
			return new ApiResponseObj()
			{
				data = context.Posts.Where(s => s.PostId == id).FirstOrDefault(),
				message = "Success Get Data!",
				status = true,
			};
		}

		// POST api/<ApiPostController>
		[HttpPost]
        public async Task<ApiResponseObj> Post()
        {

            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
                    context.Posts.Add(form);
                    await context.SaveChangesAsync();

                    await trans.CommitAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Posts.ToList(),
                        message = "Success add Data!",
                        status = true,
                    };
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return new ApiResponseObj()
                    {
                        data = null,
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
                    Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
                    var getData = await context.Posts.Where(s => s.PostId == form.PostId).FirstOrDefaultAsync();
                    getData.Category = form.Category;
                    getData.Title = form.Title;
                    getData.Content = form.Content;
                    getData.BlogId = form.BlogId;
                    context.Posts.Update(form); 

                    await context.SaveChangesAsync();
                    await trans.CommitAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Posts.ToList(),
                        message = "Success update Data!",
                        status = true,
                    };

                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return new ApiResponseObj()
                    {
                        data = null,
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
                    Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
                    var getData = await context.Posts.Where(s => s.PostId == form.PostId).FirstOrDefaultAsync();
                    context.Posts.Remove(form);
                    await context.SaveChangesAsync();

                    await trans.CommitAsync();
                    return new ApiResponseObj()
                    {
                        data = context.Posts.ToList(),
                        message = "Success delete Data!",
                        status = true,
                    };

                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return new ApiResponseObj()
                    {
                        data = null,
                        message = "Failed delete Data!" + ex.Message,
                        status = false,
                    };
                }


            }
            
		}

	}
}
