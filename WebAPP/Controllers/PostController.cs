using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.APP.Helper;
using Web.Model.APP.Blogging;
using Web.Model.APP.Master;
using Web.Repository.APP;

namespace WebAPP.Controllers
{
    public class PostController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.PostApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var result = await api.Get("api/ApiPost/Get");
            IEnumerable<Post> list = JsonConvert.DeserializeObject<IEnumerable<Post>>(result.data.ToString());

            api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var resultBlog = await api.Get("api/ApiBlog/Get");
            var Blogs = JsonConvert.DeserializeObject<List< Blog>>(resultBlog.data.ToString());
            ViewBag.LstBlog = Blogs; 
            return View(list);
        }

        // GET: BlogController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var result = await api.Get("api/ApiPost/GetBy?id=" + id);
            Post getBlogById = JsonConvert.DeserializeObject<Post>(result.data.ToString());

            
            return View(getBlogById);
        }

        // GET: BlogController/Create
        public async Task< ActionResult> Create()
        {

            ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
            ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
            BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var result = await api.Get("api/ApiBlog/Get");
            var lstBlog = JsonConvert.DeserializeObject<List< Blog>>(result.data.ToString());

            BaseRepository apimaster = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var resultMaster = await apimaster.Get("api/ApiCategory/Get");
            var lstCategory = JsonConvert.DeserializeObject<List<Category>>(resultMaster.data.ToString());
            ViewBag.LstBlog = lstBlog;
            ViewBag.LstCategory = lstCategory; 
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post form)
        {
            try
            {
                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
                var result = await api.Post("api/ApiPost/Post", form);
                IEnumerable<Post> list = JsonConvert.DeserializeObject<IEnumerable<Post>>(result.data.ToString());

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
            var result = await api.Get("api/ApiPost/GetBy?id=" + id);
            Post getBlogById = JsonConvert.DeserializeObject<Post>(result.data.ToString());

            api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
            var resultBlog = await api.Get("api/ApiBlog/Get");
            var lstBlog = JsonConvert.DeserializeObject<List<Blog>>(resultBlog.data.ToString());

            BaseRepository apimaster = new BaseRepository(Settings.GetAppSetting("MasterApiUrl"));
            var resultMaster = await apimaster.Get("api/ApiCategory/Get");
            var lstCategory = JsonConvert.DeserializeObject<List<Category>>(resultMaster.data.ToString());
            ViewBag.LstBlog = lstBlog;
            ViewBag.LstCategory = lstCategory;
            return View(getBlogById);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Post form)
        {
            try
            {

                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
                var result = await api.Post("api/ApiPost/Update", form);
                IEnumerable<Post> list = JsonConvert.DeserializeObject<IEnumerable<Post>>(result.data.ToString());
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
            var result = await api.Get("api/ApiPost/GetBy?id=" + id);
            Post getBlogById = JsonConvert.DeserializeObject<Post>(result.data.ToString());
            return View(getBlogById);
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Post form)
        {
            try
            {

                ViewBag.BlogApiUrl = Settings.GetAppSetting("BlogApiUrl");
                ViewBag.MasterApiUrl = Settings.GetAppSetting("MasterApiUrl");
                BaseRepository api = new BaseRepository(Settings.GetAppSetting("BlogApiUrl"));
                var result = await api.Post("api/ApiPost/Delete", form);
                IEnumerable<Post> list = JsonConvert.DeserializeObject<IEnumerable<Post>>(result.data.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
