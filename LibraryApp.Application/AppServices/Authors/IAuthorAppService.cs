using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryApp.Authors.DTO;

namespace LibraryApp.Authors
{
	interface IAuthorAppService:IApplicationService
	{
		IEnumerable<GetAuthorOutput> ListAll();
		Task Create(CreateAuthorInput input);
		void Update(UpdateAuthorInput input);
		void Delete(DeleteAuthorInput input);
		GetAuthorOutput GetAuthorById(GetAuthorInput input);
	}
}
