using Lemon_d.local.Database.DbModels;
using Lemon_d.local.Services;

namespace Lemon_d.local.Models
{
    public class ResultsViewModel
    {
        public List<Project> projects { get; set; }
        public string query { get; set; }
        public SearchService.Sort Sort { get; set; }
        public SearchService.SortOrder SortOrder { get; set; }
        public int TotalCount { get; set; }

        public ResultsViewModel(string q, SearchService.Sort sort, SearchService.SortOrder order)
        {
            query = q ?? string.Empty;
            SortOrder = order;
            Sort = sort;
        }
    }
}
