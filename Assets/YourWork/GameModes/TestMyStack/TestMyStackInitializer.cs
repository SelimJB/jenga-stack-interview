using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using School.Jenga;
using School.Data;
using UnityEngine;

namespace School.GameModes
{
	public class TestMyStackInitializer : MonoBehaviour
	{
		[SerializeField] TestMyStackController testMyStackController;
		[SerializeField] private DataFetcherComponent dataFetcherComponent;
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] private Boolean useGradeFilter = true;
		[SerializeField] private List<string> gradeFilter = new List<string> { "6th Grade", "7th Grade", "8th Grade" };

		private List<TowerSystem> towerSystems = new List<TowerSystem>();
		private Dictionary<string, List<Concept>> conceptsByGrade = new Dictionary<string, List<Concept>>();
		private IDataFetcher DataFetcher => dataFetcherComponent.DataFetcher;

		public List<TowerSystem> TowerSystems => towerSystems;

		private async void Start()
		{
			await InitializeGradeConcepts();
			CreateTowers();
			testMyStackController.Initialise(towerSystems);
		}

		private void CreateTowers()
		{
			var i = 0;
			foreach (var grade in conceptsByGrade.Keys)
			{
				if (useGradeFilter && !gradeFilter.Contains(grade))
				{
					Debug.Log($"Skipping grade {grade}");
					continue;
				}

				Debug.Log($"Creating tower for {grade} with {conceptsByGrade[grade].Count} concepts");
				var towerSystem = Instantiate(towerPrefab, transform).GetComponent<TowerSystem>();
				towerSystem.transform.localPosition = new Vector3((i-1) * 15, 0, 0);
				towerSystem.Label.SetText(grade);
				towerSystems.Add(towerSystem);
				
				var tower = towerSystem.Tower;
				var blocks = tower.CreateBlocks(conceptsByGrade[grade]);
				tower.CreateTower(blocks);
				tower.PositionBlocks();
				i++;
			}
		}

		private async Task InitializeGradeConcepts()
		{
			var concepts = await DataFetcher.FetchConcepts();
			foreach (var concept in concepts)
			{
				if (!conceptsByGrade.ContainsKey(concept.grade))
					conceptsByGrade[concept.grade] = new List<Concept>();

				conceptsByGrade[concept.grade].Add(concept);
			}

			foreach (var grade in conceptsByGrade.Keys)
				SortConcepts(conceptsByGrade[grade]);
		}

		private void SortConcepts(List<Concept> concepts)
		{
			concepts.Sort((a, b) =>
			{
				var domainComparison = string.Compare(a.domain, b.domain, StringComparison.Ordinal);
				if (domainComparison != 0)
				{
					return domainComparison;
				}

				var clusterComparison = string.Compare(a.cluster, b.cluster, StringComparison.Ordinal);
				if (clusterComparison != 0)
				{
					return clusterComparison;
				}

				return a.id.CompareTo(b.id);
			});
		}
	}
}