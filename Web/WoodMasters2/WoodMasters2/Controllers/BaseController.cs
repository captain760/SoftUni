using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Base controller inherited by all other controllers
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
