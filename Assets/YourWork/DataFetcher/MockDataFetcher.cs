using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace School.Data
{
	[CreateAssetMenu(fileName = "MockDataFetcher", menuName = "DataFetcher/MockDataFetcher")]
	public class MockDataFetcher : ScriptableObject, IDataFetcher
	{
		[SerializeField] private TextAsset json;

		public Task<IEnumerable<Concept>> FetchConcepts()
		{
			var concepts = JsonHelper.FromJson<Concept>(json.text);
			return Task.FromResult(concepts as IEnumerable<Concept>);
		}
	}
}