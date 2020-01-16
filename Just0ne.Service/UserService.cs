using Just0ne.Model;
using Just0ne.IRepository;
using Just0ne.IService;

namespace Just0ne.Service
{
    public class UserService : BaseService<dt_users>, IUserService
    {
        public  readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) :base(_baseRepository)
        {
            _userRepository = userRepository;

        }
    }
}