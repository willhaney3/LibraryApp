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

		[HttpGet]
		public ActionResult Delete(int id)
		{
			_authorAppService.Delete(new DeleteAuthorInput { Id = id });
			return RedirectToAction("Index", "Will");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var author = _authorAppService.GetAuthorById(new GetAuthorInput { Id = id });

			return View(author);
			
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

		[HttpPost]
		public ActionResult Update(int id, string DisplayName, DateTime BirthDate)
		{
			var output = new UpdateAuthorInput
			{
				Id = id,
				DisplayName = DisplayName,
				BirthDate = BirthDate,
				CreationTime = DateTime.Now
			};

			_authorAppService.Update(output);

			return RedirectToAction("Index", "Will");
		}


	}
}