using EMS.Business.Models;

namespace EMS.Business.DomainServices
{
	public class DataAccessFactory : IDataAccessFactory
	{
		public List<IDataAccess> DataAccess { get; set; }

		public DataAccessFactory(List<IDataAccess> pDataAccess) => DataAccess = pDataAccess;

		public T GetDL<T>()
		{
			T? Value = default;

			try
			{
				foreach (IDataAccess DL in DataAccess)
				{
					Type tDL = DL.GetType();

					foreach (Type iT in tDL.GetInterfaces())
					{
						if (iT.Name == typeof(T).Name)
						{
							Value = (T)DL;
							break;
						}
					}

					if (Value != null) break;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return Value;
		}
	}
}
