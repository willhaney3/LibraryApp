using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace LibraryApp.DomainServices.Categories
{
	public interface ICategoryManager : IDomainService
	{
		IEnumerable<Category> GetAllListCategories();
		Category GetCategoryById(int id);
		Task<Category> Create(Category entity);
		void Update(Category entity);
		void Delete(int id);
	}

}
