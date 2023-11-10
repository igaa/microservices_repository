using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.APP.Helper;
using Web.Model.APP.Blogging;
using Web.Model.APP.Master;
using Web.Repository.APP;

namespace Web.APP.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var result = await api.Get("api/ApiCategory/Get");
            IEnumerable<Category> list = JsonConvert.DeserializeObject<IEnumerable<Category>>(result.data.ToString());
            return View(list);
        }

        // GET: BlogController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var result = await api.Get("api/ApiCategory/GetBy?id=" + id);
            Category getBlogById = JsonConvert.DeserializeObject<Category>(result.data.ToString());
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
        public async Task<ActionResult> Create(Category form)
        {
            try
            {
                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
                var result = await api.Post("api/ApiCategory/Post", form);
                IEnumerable<Category> list = JsonConvert.DeserializeObject<IEnumerable<Category>>(result.data.ToString());

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
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var result = await api.Get("api/ApiCategory/GetBy?id=" + id);
            Category getBlogById = JsonConvert.DeserializeObject<Category>(result.data.ToString());
            return View(getBlogById);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category form)
        {
            try
            {

                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
                var result = await api.Post("api/ApiCategory/Update", form);
                IEnumerable<Category> list = JsonConvert.DeserializeObject<IEnumerable<Category>>(result.data.ToString());
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
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var result = await api.Get("api/ApiCategory/GetBy?id=" + id);
            Category getBlogById = JsonConvert.DeserializeObject<Category>(result.data.ToString());
            return View(getBlogById);
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Category form)
        {
            try
            {

                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
                var result = await api.Post("api/ApiCategory/Delete", form);
                IEnumerable<Category> list = JsonConvert.DeserializeObject<IEnumerable<Category>>(result.data.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
