using UnityEngine;

namespace School.Data
{
	public class DataFetcherComponent : MonoBehaviour
	{
		[SerializeField] private MockDataFetcher mockDataFetcher;
		[SerializeField] private DataFetcher dataFetcher;
		[SerializeField] private bool useMockDataFetcher;

		public IDataFetcher DataFetcher => useMockDataFetcher ? mockDataFetcher : dataFetcher;
	}
}