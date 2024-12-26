
namespace WebApplication2
{
    public class InMemoryRepository : IUserRepository
    {
        private readonly List<string> users = [];

        public IEnumerable<string> Users => users;

        public void Add(string user)
        {
            users.Add(user);
        }
    }
}
