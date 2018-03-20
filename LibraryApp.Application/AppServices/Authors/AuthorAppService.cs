using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using LibraryApp.AppServices.Authors.DTO;
using LibraryApp.DomainServices.Authors;

namespace LibraryApp.AppServices.Authors
{
	public class AuthorAppService:ApplicationService, IAuthorAppService
	{

		private readonly IAuthorManager _authorManager;

		public AuthorAppService(IAuthorManager authorManager)
		{
			_authorManager = authorManager;
		}


		public IEnumerable<GetAuthorOutput> ListAll()
		{
			var getAll = _authorManager.GetAllListAuthors().ToList();
			var output = Mapper.Map<List<Author>, List<GetAuthorOutput>>(getAll);
			return output;
		}

		public async Task Create(CreateAuthorInput input)
		{
			//var output = Mapper.Map<CreateAuthorInput, Author>(input);

			var output = new Author()
			{
				DisplayName = input.DisplayName,
				BirthDate = input.BirthDate,
				CreatorUserId = 1,
			};

			await _authorManager.Create(output);
		}

		public void Update(UpdateAuthorInput input)
		{
			var output = Mapper.Map<UpdateAuthorInput, Author>(input);
			_authorManager.Update(output);

		}

		public void Delete(DeleteAuthorInput input)
		{
			_authorManager.Delete(input.Id);
		}

		public GetAuthorOutput GetAuthorById(GetAuthorInput input)
		{
			var getAuthor = _authorManager.GetAuthorById(input.Id);
			var output = Mapper.Map<Author, GetAuthorOutput>(getAuthor);
			return output;
		}
	}
}
