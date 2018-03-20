using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.AppServices.Authors.DTO
{
	public class GetAuthorOutput
	{
		[Key]
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime? DeathDate { get; set; }
	}

}
