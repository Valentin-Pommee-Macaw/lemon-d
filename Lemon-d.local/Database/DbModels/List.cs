using Lemon_d.local.Database.DbModels.Identity;
using Lemon_d.local.Database.DbModels._AdditionalClasses;
using Lemon_d.local.Database.DbModels._AdditionalClasses.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lemon_d.local.Database.DbModels
{
    public class ProjectList
    {
        public string Name { get; set; }
        [Key]
        public Guid ID { get; set; }
        public List<Project> Projects { get; set; }
        public List<Note>? Notes { get; set; }
        public AppUser? CreatedBy { get; set; }
        public Priority Priority { get; set; }

        public ProjectList(string name) {
            this.ID = Guid.NewGuid();
            this.Projects = new List<Project>();
            this.Priority = Priority.Medium;

            this.Name = name;
        }

        public ProjectList(string name, Project p)
        {
            this.ID = Guid.NewGuid();
            this.Projects = new List<Project>();
            this.Priority = Priority.Medium;

            this.Name = name;
            this.Projects.Add(p);
        }

        public ProjectList(string name, IEnumerable<Project> p)
        {
            this.ID = Guid.NewGuid();
            this.Projects = new List<Project>();
            this.Priority = Priority.Medium;

            this.Name = name;
            this.Projects.AddRange(p);
        }
    }
}
