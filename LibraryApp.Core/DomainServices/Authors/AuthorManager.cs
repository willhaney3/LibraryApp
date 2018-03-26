using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace LibraryApp.DomainServices.Authors
{
	public class AuthorManager : DomainService, IAuthorManager
	{
		public IRepository<Author> _repositoryAuthor { get; set; }

		public IEnumerable<Author> GetAllListAuthors()
		{
			return _repositoryAuthor.GetAllIncluding(x => x.Books);
		}

		public Author GetAuthorById(int id)
		{
			return _repositoryAuthor.Get(id);

		}

		public async Task<Author> Create(Author entity)
		{
			var author = _repositoryAuthor.FirstOrDefault(x => x.Id == entity.Id);
			if (author != null)
			{
				throw new UserFriendlyException("Already Exists");
			}
			else
			{
				return await _repositoryAuthor.InsertAsync(entity);
			}

		}

		public async void Update(Author entity)
		{
			// original method from demo app updates CreationTime and puts NULL in CreatorUserId
			//_repositoryAuthor.Update(entity);

			var author = await _repositoryAuthor.GetAsync(entity.Id);

			if (author == null)
			{
				throw new UserFriendlyException(L("CouldNotFindTheTaskMessage"));
			}
			// this performs the update in the database
			//entity.MapTo(author);

			author.DisplayName = entity.DisplayName;
			author.BirthDate = entity.BirthDate;
			
			
		}

		public void Delete(int id)
		{
			var author = _repositoryAuthor.FirstOrDefault(x => x.Id == id);

			if (author == null)
			{
				throw new UserFriendlyException("No Data Found");
			}
			else
			{
				_repositoryAuthor.Delete(author);
			}
		}
	}
}
