using System;
namespace Barberland.Model
{
	public class ResponseModel<T>
	{
		public int StatusCode { get; set; }
		public string? Message { get; set; }
		public T? Object { get; set; }
	}
}

