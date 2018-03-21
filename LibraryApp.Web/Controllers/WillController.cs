using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using LibraryApp.AppServices.Authors;
using LibraryApp.AppServices.Authors.DTO;

namespace LibraryApp.Web.Controllers
{
	public class WillController : LibraryAppControllerBase
	{

		public IAuthorAppService _authorAppService { get; set; }

		// GET: Will
		[HttpGet]
		public ActionResult Index()
		{
			return View(_authorAppService.ListAll());
		}

		[HttpGet]
		public ActionResult New()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Register(string DisplayName, DateTime BirthDate)
		{
			 _authorAppService.Create(new CreateAuthorInput()
			{
				BirthDate = BirthDate,
				DisplayName = DisplayName,
				CreationTime = DateTime.Now,
				DeathDate = null
			});

			return RedirectToAction("Index", "Will");
		}
	}
}