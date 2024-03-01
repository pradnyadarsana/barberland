using System;
namespace Barberland.Utility
{
	public class AppSettings
	{
		public URLSettings URLSettings { get; set; }
		public GoogleServices GoogleServices { get; set; }	
	}

	public class URLSettings
	{
		public string NoImageThumbnailURL { get; set; }
	}

    public class GoogleServices
    {
		public string GoogleAPIKey { get; set; }
	}
}

