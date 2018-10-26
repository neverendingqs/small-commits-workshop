using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCommitsWorkshop.Models;

namespace SmallCommitsWorkshop.Controllers {
	[Route( "api/[controller]" )]
	public class UsersController : Controller {
		private readonly UsersContext m_usersContext;

		public UsersController( UsersContext usersContext ) {
			m_usersContext = usersContext;

			if( !m_usersContext.Users.Any() ) {
				m_usersContext.Users.Add( new User() { Id = 169, UserName = "D2LSupport" } );
				m_usersContext.Users.Add( new User() { Id = 175, UserName = "user1" } );
				m_usersContext.SaveChanges();
			}
		}

		[HttpGet]
		public ActionResult<IDictionary<long, string>> GetAll() =>
			m_usersContext
				.Users
				.ToDictionary( user => user.Id, user => user.UserName );
	}
}
