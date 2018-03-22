using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Security.AntiForgery;
using LibraryApp.AppServices.Authors;
using LibraryApp.AppServices.Authors.DTO;
using LibraryApp.DomainServices.Authors;

namespace LibraryApp.Web.Controllers
{
	public class WillController : LibraryAppControllerBase,ITaskAppService
	{
		public IRepository<Author> _taskRepository { get; set; }


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

		[DisableAbpAntiForgeryTokenValidation]
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

		[DisableAbpAntiForgeryTokenValidation]
		[HttpPost]
		public ActionResult Update(int id, string DisplayName, DateTime BirthDate)
		{
			var output = new UpdateAuthorInput
			{
				Id = id,
				DisplayName = DisplayName,
				BirthDate = BirthDate
			};

			_authorAppService.Update(output);

			return RedirectToAction("Index", "Will");
		}

		public async Task<ActionResult> Update2(int id, string DisplayName, DateTime BirthDate)
		{

			var input = new UpdateAuthorInput
			{
				Id = id,
				DisplayName = DisplayName,
				BirthDate = BirthDate
			};

			var author =  await _taskRepository.FirstOrDefaultAsync(input.Id);
			if (author == null)
			{
				throw new UserFriendlyException(L("CouldNotFindTheTaskMessage"));
			}
			input.MapTo(author);

			return  RedirectToAction("Index", "Will");
		}
	}

	internal interface ITaskAppService
	{
		Task<ActionResult> Update2(int id, string DisplayName, DateTime BirthDate);
	}

}