﻿using System;

namespace LibraryApp.AppServices.Authors.DTO
{
	public class GetAuthorInput
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime? DeathDate { get; set; }
	}
}
