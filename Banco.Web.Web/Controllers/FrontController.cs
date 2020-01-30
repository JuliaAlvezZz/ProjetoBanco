using System.Web.Mvc;

namespace Banco.Web.Web.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        public ActionResult Index()
        {
            return View();
        }
    }
}