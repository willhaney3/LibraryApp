using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Authors.DTO
{
public	class GetBookInput
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public int? TotalPageNumber { get; set; }
		public int AuthorId { get; set; }
		public int CategoryId { get; set; }
	}
}
