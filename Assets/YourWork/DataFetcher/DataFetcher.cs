using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace School.Data
{
	[CreateAssetMenu(fileName = "DataFetcher", menuName = "DataFetcher/DataFetcher")]
	public class DataFetcher : ScriptableObject, IDataFetcher
	{
		[SerializeField] private string url;

		public async Task<IEnumerable<Concept>> FetchConcepts()
		{
			var json = await FetchJson(url);
			return JsonHelper.FromJson<Concept>(json);
		}

		private async Task<string> FetchJson(string url)
		{
			using (var httpClient = new HttpClient())
			{
				var response = await httpClient.GetAsync(url);

				response.EnsureSuccessStatusCode();

				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}