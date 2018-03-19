using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryApp.AppServices.Categories.DTO;

namespace LibraryApp.AppServices.Categories
{
	public interface ICategoryAppService : IApplicationService
	{
		IEnumerable<GetCategoryOutput> ListAll();
		Task Create(CreateCategoryInput input);
		void Update(UpdateCategoryInput input);
		void Delete(DeleteCategoryInput input);
		GetCategoryOutput GetCategoryById(GetCategoryInput input);
	}
}
