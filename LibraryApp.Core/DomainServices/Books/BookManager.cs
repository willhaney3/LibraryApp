using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace LibraryApp.DomainServices.Books
{
	public class BookManager : DomainService, IBookManager
	{
		private readonly IRepository<Book> _repositoryBook;

		public BookManager(IRepository<Book> repositoryBook)
		{
			_repositoryBook = repositoryBook;
		}

		public IEnumerable<Book> GetAllListBooks()
		{
			return _repositoryBook.GetAll();
		}

		public Book GetBookById(int id)
		{
			return _repositoryBook.Get(id);
		}

		public async Task<Book> Create(Book entity)
		{
			var Book = _repositoryBook.FirstOrDefault(x => x.Id == entity.Id);
			if (Book != null)
			{
				throw new UserFriendlyException("Already Exists");
			}
			else
			{
				return await _repositoryBook.InsertAsync(entity);
			}

		}

		public void Update(Book entity)
		{
			_repositoryBook.Update(entity);
		}

		public void Delete(int id)
		{
			var Book = _repositoryBook.FirstOrDefault(x => x.Id == id);

			if (Book == null)
			{
				throw new UserFriendlyException("No Data Found");
			}
			else
			{
				_repositoryBook.Delete(Book);
			}
		}
	}
}
