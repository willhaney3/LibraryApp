using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryApp.AppServices.Categories.DTO;

namespace LibraryApp.AppServices.Categories
{
	class CategoryAppService : ApplicationService, ICategoryAppService
	{
		public IEnumerable<GetCategoryOutput> ListAll()
		{
			throw new NotImplementedException();
		}

		public Task Create(CreateCategoryInput input)
		{
			throw new NotImplementedException();
		}

		public void Update(UpdateCategoryInput input)
		{
			throw new NotImplementedException();
		}

		public void Delete(DeleteCategoryInput input)
		{
			throw new NotImplementedException();
		}

		public GetCategoryOutput GetCategoryById(GetCategoryInput input)
		{
			throw new NotImplementedException();
		}
	}
}
