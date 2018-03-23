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

		//private readonly IRepository<Author> _repositoryAuthor;

		//public AuthorManager(IRepository<Author> repositoryAuthor)
		//{
		//	_repositoryAuthor = repositoryAuthor;
		//}

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

		public void Update(Author entity)
		{
			//_repositoryAuthor.Update(entity);

			var author = _repositoryAuthor.Get(entity.Id);
			if (author == null)
			{
				throw new UserFriendlyException(L("CouldNotFindTheTaskMessage"));
			}
			entity.MapTo(author);


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
