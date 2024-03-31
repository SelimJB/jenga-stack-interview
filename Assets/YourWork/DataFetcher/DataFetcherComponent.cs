using UnityEngine;

namespace School.Data
{
	public class DataFetcherComponent : MonoBehaviour
	{
		[SerializeField] private MockDataFetcher mockDataFetcher;
		[SerializeField] private DataFetcher dataFetcher;
		[SerializeField] private bool useMockDataFetcher;

		private async void Start()
		{
			var concepts = useMockDataFetcher ? await mockDataFetcher.FetchConcepts() : await dataFetcher.FetchConcepts();

			foreach (var concept in concepts)
			{
				Debug.Log(concept.subject);
			}
		}
	}
}