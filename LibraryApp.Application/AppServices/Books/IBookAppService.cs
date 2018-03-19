using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace LibraryApp.Authors.DTO
{
public interface IBookAppService:IApplicationService
	{
		IEnumerable<GetBookOutput> ListAll();
		Task Create(CreateBookInput input);
		void Update(UpdateBookInput input);
		void Delete(DeleteBookInput input);
		GetBookOutput GetBookById(GetBookInput input);
	}
}
