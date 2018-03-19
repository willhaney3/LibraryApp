using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.AppServices.Authors;

namespace LibraryApp.Web.Controllers
{
	public class WillController : LibraryAppControllerBase
	{
		private readonly IAuthorAppService _authorAppService;

		public WillController(IAuthorAppService authorAppService)
		{
			_authorAppService = authorAppService;
		}

		// GET: Will
		public ActionResult Index()
		{

			var x = _authorAppService.ListAll();

			return View(x);
		}

		// GET: Will/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Will/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Will/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Will/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Will/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Will/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Will/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
