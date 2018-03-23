using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using LibraryApp.AppServices.Authors.DTO;
using LibraryApp.Authorization.Roles;
using LibraryApp.Authorization.Users;
using LibraryApp.DomainServices.Authors;
using LibraryApp.Roles.Dto;
using LibraryApp.Users.Dto;

namespace LibraryApp
{
	[DependsOn(typeof(LibraryAppCoreModule), typeof(AbpAutoMapperModule))]
	public class LibraryAppApplicationModule : AbpModule
	{
		public override void PreInitialize()
		{

		}

		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

			// TODO: Is there somewhere else to store these, with the dto classes
			Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
			{

				//cfg.CreateMap<CreateAuthorInput, Author>().ForAllOtherMembers(o => o.Ignore());
				cfg.CreateMap<CreateAuthorInput, Author>();

				//cfg.CreateMap<UpdateAuthorInput, Author>().ForAllOtherMembers(o => o.Ignore());
				cfg.CreateMap<UpdateAuthorInput, Author>();
				cfg.CreateMap<Author, Author>();


				// Role and permission
				cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
				cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

				cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
				cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());

				cfg.CreateMap<UserDto, User>();
				cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

				cfg.CreateMap<CreateUserDto, User>();
				cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
			});
		}
	}
}
