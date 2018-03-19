using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
	interface IBookManager
	{
		IEnumerable<Book> GetAllListBooks();
		Book GetBookById(int id);
		Task<Book> Create(Book entity);
		void Update(Book entity);
		void Delete(int id);
	}
}
