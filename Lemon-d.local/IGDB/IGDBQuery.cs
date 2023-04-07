using Lemon_d.local.Services;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections;

namespace Lemon_d.local.IGDB
{
	#region old :(
//	public class IGDBQuery
//	{
//		public List<IGDBQueryPartial> Partials { get; private set; } = new List<IGDBQueryPartial>();

//		#region Methods
//		public override string ToString()
//		{
//			StringBuilder builder = new StringBuilder();
//			//logic here...
//			return builder.ToString();
//		}
//		#endregion
//	}

//	public class IGDBQueryPartial
//	{
//		#region Properties
//		public Endpoint Endpoint { get; private set; }
//		public string Name { get; private set; }
//		public QueryType QueryType { get; private set; }
//		public List<string> PropertiesToReturn { get; private set; }
//		public LimitOffset Paging { get; private set; }
//		public string? FilterBody { get; private set; }
//		#endregion

//		#region Nested Classes
//		public class LimitOffset
//		{
//			public int Limit { get; private set; }
//			public int Offset { get; private set; }

//			public LimitOffset(int limit, int offset)
//			{
//				Limit = limit;
//				Offset = offset;
//			}
//		}
//		#endregion

//		#region Methods
//		public bool ValidateProps(List<string> propertiesToReturn) {
//			bool propsValid = false;
//			switch (Endpoint)
//			{
//				case Endpoint.Games:
//					propsValid = _ValidateProps(typeof(Properties.Games), propertiesToReturn);
//					break;
//				case Endpoint.Companies:
//					propsValid = _ValidateProps(typeof(Properties.Companies), propertiesToReturn);
//					break;
//			}
//			return propsValid;
//		}

//		public void AppendFilters(string filters, QueryType type)
//		{
//			StringBuilder builder;
//			if (type == QueryType.Search && type == this.QueryType)
//			{
//				builder = new StringBuilder("search ");
//				builder.Append($"\"{filters}\";");
//			}
//			else if (type == QueryType.Filter && type == this.QueryType)
//			{
//				builder = new StringBuilder("where ");
//				builder.Append($"{filters};");
//			}
//			else
//			{
//				builder = new StringBuilder();
//			}
//			this.FilterBody = builder.ToString();
//		}

//		/// <summary>
//		/// Determines whether the propertiesToReturn are valid for the given Endpoint
//		/// </summary>
//		/// <param name="type"></param>
//		/// <param name="propertiesToReturn"></param>
//		/// <returns></returns>
//		private bool _ValidateProps(Type type, List<string> propertiesToReturn)
//		{
//			IEnumerable<string> validProperties = propertiesToReturn.Where(p =>
//				type.GetFields().Any(f => f.GetValue(null) as string == p)
//			);

//			var invalidProps = propertiesToReturn.Except(validProperties);

//			if (invalidProps.Any())
//			{
//				throw new ApplicationException($"Found {invalidProps.Count()} invalid properties: {String.Join(", ", invalidProps)}");
//			}
//			else
//			{
//				return true;
//			}
//		}
//		#endregion

//		#region Constructors
//		public IGDBQueryPartial(Endpoint endpoint, string name, QueryType queryType, List<string> propertiesToReturn, LimitOffset limitOffset)
//		{
//			Endpoint = endpoint;
//			Name = name;
//			QueryType = queryType;
//			if (ValidateProps(propertiesToReturn))
//			{
//				PropertiesToReturn = propertiesToReturn;
//			}
//			else
//			{
//				PropertiesToReturn = new List<string>() { Properties.Default };
//			}
//			Paging = limitOffset;
//		}
//		#endregion
//	}

//	#region Enums
//	public enum QueryType
//	{
//		Search = 1,
//		Filter = 2,
//	}

//	public enum Endpoint
//	{
//		Games = 1,
//		Companies = 2,
//}
//	#endregion
	#endregion
}