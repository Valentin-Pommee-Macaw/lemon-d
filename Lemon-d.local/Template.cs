﻿namespace Lemon_d.local
{
	public partial struct Template
	{
		public struct Search
		{
			public struct Configuration
			{
				public static readonly string[] SEARCH_LOCATIONS = new string[] { "Game.Name", "Company.Developed.Name", "Company.Published.Name" };
			}
		}

		public struct API
		{
			public struct Authorization {
				public static readonly string CLIENT_ID = "r2lsfz5pmuqqo5sqif9c8dcmfi9g1y";
				public static readonly string CLIENT_SECRET = "ui3u9wimjbhfqmwmtnd8bfc5v287e3";
			}
		}
	}
}
