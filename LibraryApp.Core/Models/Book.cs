﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace LibraryApp.Models
{
	public class Book: FullAuditedEntity
	{
		[Required]
		[Display(Name = "Display Name")]
		[StringLength(64, ErrorMessage = "Maximum Length is 64")]
		public string DisplayName { get; set; }
		public int? TotalPageNumber { get; set; }

		[ForeignKey("Author")]
		public int AuthorId { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		public virtual Author Author { get; set; }
		public virtual Category Category { get; set; }

	}
}
