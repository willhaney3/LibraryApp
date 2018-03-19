using System;

namespace LibraryApp.AppServices.Books.DTO
{
public	class CreateBookInput
	{
		public string DisplayName { get; set; }
		public DateTime CreationTime { get; set; }
		public int? TotalPageNumber { get; set; }
		public int AuthorId { get; set; }
		public int CategoryId { get; set; }
	}
}
