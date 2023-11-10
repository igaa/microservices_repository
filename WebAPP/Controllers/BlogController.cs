using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Model.APP.Blogging; 
using Newtonsoft.Json;
using Web.APP.Helper;
using Web.Repository.APP;

namespace WebAPP.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        public async Task<ActionResult> Index()
        {
            ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var result = await api.Get("api/ApiBlog/Get");
            IEnumerable<Blog> list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(result.data.ToString()); 
            return View(list);
        }

        // GET: BlogController/Details/5
        public async Task<ActionResult> Details(int id)
        {

			ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
			ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
			BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
			var result = await api.Get("api/ApiBlog/GetBy?id="+ id);
			Blog getBlogById = JsonConvert.DeserializeObject<Blog>(result.data.ToString());
			return View(getBlogById);
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAction(Blog form)
        {
            try
            {
				ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
				ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
				BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
				var result = await api.Post("api/ApiBlog/Post", form);
                IEnumerable<Blog> list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(result.data.ToString());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

			ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
			ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
			BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
			var result = await api.Get("api/ApiBlog/GetBy?id=" + id);
			Blog getBlogById = JsonConvert.DeserializeObject<Blog>(result.data.ToString());
			return View(getBlogById);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Blog form)
        {
            try
            {

				ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
				ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
				BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
				var result = await api.Post("api/ApiBlog/Update", form);
				IEnumerable<Blog> list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(result.data.ToString());
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
			ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
			ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
			BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
			var result = await api.Get("api/ApiBlog/GetBy?id=" + id);
			Blog getBlogById = JsonConvert.DeserializeObject<Blog>(result.data.ToString());
			return View(getBlogById);
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Blog form)
        {
            try
            {

				ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
				ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
				BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
				var result = await api.Post("api/ApiBlog/Delete", form);
				IEnumerable<Blog> list = JsonConvert.DeserializeObject<IEnumerable<Blog>>(result.data.ToString());
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
