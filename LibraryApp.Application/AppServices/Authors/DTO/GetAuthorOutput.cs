﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Authors.DTO
{
	public class GetAuthorOutput
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime? DeathDate { get; set; }
	}

}
