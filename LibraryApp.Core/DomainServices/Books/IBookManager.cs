using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace LibraryApp.DomainServices.Books
{
	public interface IBookManager : IDomainService
	{
		IEnumerable<Book> GetAllListBooks();
		Book GetBookById(int id);
		Task<Book> Create(Book entity);
		void Update(Book entity);
		void Delete(int id);
	}
}
