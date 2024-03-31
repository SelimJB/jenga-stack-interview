using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Data
{
	public interface IDataFetcher
	{
		Task<IEnumerable<Concept>> FetchConcepts();
	}
}