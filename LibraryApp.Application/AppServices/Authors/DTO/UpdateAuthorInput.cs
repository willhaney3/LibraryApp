using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.AppServices.Authors.DTO
{
	public class UpdateAuthorInput
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }


		[DataType(DataType.DateTime)]
		public DateTime BirthDate { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime? DeathDate { get; set; }
	}
}
