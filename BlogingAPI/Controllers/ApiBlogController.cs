using BlogingAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Model.APP;
using Web.Model.APP.Blogging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Bloging.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiBlogController : ControllerBase
    {
        BlogingContext context = new BlogingContext();

        [HttpGet]
        public ApiResponseObj Get()
        {
            return new ApiResponseObj()
            {
                data = context.Blogs.ToList(), 
                message = "Success Get Data!", 
                status = true, 
            };
        }

		[HttpGet]
		public ApiResponseObj GetBy(int id)
		{
			return new ApiResponseObj()
			{
				data = context.Blogs.Where(s => s.BlogId == id).FirstOrDefault(),
				message = "Success Get Data!",
				status = true,
			};
		}

		// POST api/<ApiBlogController>
		[HttpPost]
        public async Task<ApiResponseObj> Post()
        {
            Blog form = HttpContext.Request.ReadFromJsonAsync<Blog>().Result;
            context.Blogs.Add(form);
            await context.SaveChangesAsync();

            return new ApiResponseObj()
			{
				data = context.Blogs.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}


		[HttpPost]
		public async Task<ApiResponseObj> Update()
		{
			Blog form = HttpContext.Request.ReadFromJsonAsync<Blog>().Result;
			var getData = await context.Blogs.Where(s => s.BlogId == form.BlogId).FirstOrDefaultAsync();
			getData.Url = form.Url;
			context.Blogs.Update(getData); 
			await context.SaveChangesAsync();

			return new ApiResponseObj()
			{
				data = context.Blogs.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

		[HttpPost]
		public async Task<ApiResponseObj> Delete()
		{
			Blog form = HttpContext.Request.ReadFromJsonAsync<Blog>().Result;
			var getData = await context.Blogs.Where(s => s.BlogId == form.BlogId).FirstOrDefaultAsync();
			context.Blogs.Remove(getData);
            await context.SaveChangesAsync();

            return new ApiResponseObj()
			{
				data = context.Blogs.ToList(),
				message = "Success add Data!",
				status = true,
			};
		}

	}
}
