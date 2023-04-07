namespace Lemon_d.local.Models
{
	public class SearchResultModel
	{
		#region Properties

		public List<object> Results { get; set; }

		#endregion

		#region Constructors

		public SearchResultModel()
		{
			if (this.Results == null)
			{
				object[] results = new object[1];
				this.Results = results.ToList();
			}
		}

		#endregion
	}

}
