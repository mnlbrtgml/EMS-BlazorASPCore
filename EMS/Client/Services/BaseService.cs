namespace EMS.Client.Services
{
	public abstract class BaseService
	{
		public readonly HttpClient httpClient;

		protected BaseService(HttpClient phttpClient)
		{
			httpClient = phttpClient;
		}
	}
}
