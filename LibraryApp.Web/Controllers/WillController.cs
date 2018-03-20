using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using LibraryApp.AppServices.Authors.DTO;

namespace LibraryApp.Web.Controllers
{
	public class WillController : LibraryAppControllerBase
	{
		private readonly LibraryApp.AppServices.Authors.IAuthorAppService _authorAppService;
		public WillController(LibraryApp.AppServices.Authors.IAuthorAppService authorAppService)
		{
			_authorAppService = authorAppService;
		}

		// GET: Will
		[HttpGet]
		public ActionResult Index()
		{

			var x = _authorAppService.ListAll();

			return View(x);
		}

		[HttpPost]
		public async Task Register(string DisplayName, DateTime BirthDate)
		{

			await _authorAppService.Create(new CreateAuthorInput()
			{
				BirthDate = BirthDate,
				DisplayName = DisplayName,
				CreationTime = DateTime.Now,
			DeathDate = null


			});

			
		}
	}
}