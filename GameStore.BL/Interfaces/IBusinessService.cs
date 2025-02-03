using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BL.Interfaces
{
	public interface IBusinessService
	{
		Task<decimal> CalculateTotalGamePriceAsync(IEnumerable<Guid> gameIds);
		Task<int> CountGamesByGenreAsync(string genre);
	}
}
