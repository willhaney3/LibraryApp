using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using LibraryApp.DomainServices.Books;

namespace LibraryApp.DomainServices.Authors
{
		[Table("Author")]
	public class Author: FullAuditedEntity<int>
	{
		
		public Author()
		{
			Books = new HashSet<Book>();
		}

		[Required]
		[Display(Name = "Display Name")]
		[StringLength(64, ErrorMessage = "Maximum Length is 64")]
		public string DisplayName { get; set; }
		
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime BirthDate { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? DeathDate { get; set; }

		public virtual ICollection<Book> Books { get; set; }

	}
}
