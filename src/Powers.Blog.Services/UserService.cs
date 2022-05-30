using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powers.Blog.Services
{
    public class UserService : ServiceGen<User>, IUserService
    {
        public UserService(IRepositoryGen<User> repository) : base(repository)
        {
        }
    }
}