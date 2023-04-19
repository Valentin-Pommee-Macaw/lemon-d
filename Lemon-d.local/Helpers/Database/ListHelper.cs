using Lemon_d.local.Database.DbModels;

namespace Lemon_d.local.Helpers.Database
{
    public class ListHelper
    {
        private readonly MasterDbContext _ctx;
        public ListHelper(MasterDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProjectList CreateList(string name)
        {
            ProjectList li = new ProjectList(name);
            _ctx.Lists.Add(li);
            return li;
        }

        public ProjectList CreateList(string name, Project project)
        {
            ProjectList li = new ProjectList(name, project);
            _ctx.Lists.Add(li);
            return li;
        }
    }
}
