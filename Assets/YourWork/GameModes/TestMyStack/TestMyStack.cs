using System.Collections.Generic;
using System.Threading.Tasks;
using School.Jenga;
using School.Data;
using UnityEngine;

namespace School.GameModes
{
	public class TestMyStack : MonoBehaviour
	{
		[SerializeField] private DataFetcherComponent dataFetcherComponent;
		[SerializeField] private GameObject towerPrefab;

		private List<Tower> towers = new List<Tower>();
		private Dictionary<string, List<Concept>> conceptsByGrade = new Dictionary<string, List<Concept>>();
		private IDataFetcher DataFetcher => dataFetcherComponent.DataFetcher;

		private async void Start()
		{
			await InitializeGradeConcepts();

			var i = 0;
			foreach (var grade in conceptsByGrade.Keys)
			{
				Debug.Log(grade);
				var tower = Instantiate(towerPrefab, transform).GetComponent<Tower>();
				towers.Add(tower);
			
				var blocks = tower.CreateBlocks(conceptsByGrade[grade]);
				tower.CreateTower(blocks);
				tower.PositionBlocks();
				tower.transform.position = new Vector3(i*15, 0, 0);
				i++;
			}
		}

		private async Task InitializeGradeConcepts()
		{
			var concepts = await DataFetcher.FetchConcepts();
			foreach (var concept in concepts)
			{
				if (!conceptsByGrade.ContainsKey(concept.grade))
				{
					conceptsByGrade[concept.grade] = new List<Concept>();
				}

				conceptsByGrade[concept.grade].Add(concept);
			}
		}
	}
}