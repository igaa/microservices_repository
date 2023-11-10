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
            Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
            context.Posts.Add(form);
            await context.SaveChangesAsync();

            return new ApiResponseObj()
			{
				data = context.Posts.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}


		[HttpPost]
		public async Task<ApiResponseObj> Update()
		{
			Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
			var getData = await context.Posts.Where(s => s.PostId == form.PostId).FirstOrDefaultAsync();
			getData.Category = form.Category;
			getData.Title = form.Title;
			getData.Content = form.Content; 
			getData.BlogId = form.BlogId;
			context.Posts.Update(form);
            context.SaveChanges();

            return new ApiResponseObj()
			{
				data = context.Posts.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

		[HttpPost]
		public async Task<ApiResponseObj> Delete()
		{
			Post form = HttpContext.Request.ReadFromJsonAsync<Post>().Result;
			var getData = await context.Posts.Where(s => s.PostId == form.PostId).FirstOrDefaultAsync();
			context.Posts.Remove(form);
            context.SaveChanges();

            return new ApiResponseObj()
			{
				data = context.Posts.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

	}
}
