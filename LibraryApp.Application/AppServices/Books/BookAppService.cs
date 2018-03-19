using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using LibraryApp.AppServices.Books.DTO;
using LibraryApp.DomainServices.Books;

namespace LibraryApp.AppServices.Books
{
	public class BookAppService : ApplicationService, IBookAppService
	{

		private readonly IBookManager _BookManager;

		public BookAppService(IBookManager BookManager)
		{
			_BookManager = BookManager;
		}


		public IEnumerable<GetBookOutput> ListAll()
		{
			var getAll = _BookManager.GetAllListBooks().ToList();
			var output = Mapper.Map<List<Book>, List<GetBookOutput>>(getAll);
			return output;
		}

		public async Task Create(CreateBookInput input)
		{
			var output = Mapper.Map<CreateBookInput, Book>(input);
			await _BookManager.Create(output);
		}

		public void Update(UpdateBookInput input)
		{
			var output = Mapper.Map<UpdateBookInput, Book>(input);
			_BookManager.Update(output);

		}

		public void Delete(DeleteBookInput input)
		{
			_BookManager.Delete(input.Id);
		}

		public GetBookOutput GetBookById(GetBookInput input)
		{
			var getBook = _BookManager.GetBookById(input.Id);
			var output = Mapper.Map<Book, GetBookOutput>(getBook);
			return output;
		}
	}

}
