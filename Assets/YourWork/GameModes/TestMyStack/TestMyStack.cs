using System;
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
		[SerializeField] private Boolean useGradeFilter = true;
		[SerializeField] private List<string> gradeFilter = new List<string> { "6th Grade", "7th Grade", "8th Grade" };

		private List<Tower> towers = new List<Tower>();
		private Dictionary<string, List<Concept>> conceptsByGrade = new Dictionary<string, List<Concept>>();
		private IDataFetcher DataFetcher => dataFetcherComponent.DataFetcher;

		private void OnGUI()
		{
			if (GUI.Button(new Rect(10, 10, 350, 200), "Start"))
			{
				foreach (var tower in towers)
				{
					tower.ApplyBlockBehaviors();
				}
			}

			if (GUI.Button(new Rect(10, 220, 350, 200), "Reset"))
			{
				foreach (var tower in towers)
				{
					tower.Reset();
				}
			}
		}

		private async void Start()
		{
			await InitializeGradeConcepts();

			var i = 0;
			foreach (var grade in conceptsByGrade.Keys)
			{
				if (useGradeFilter && !gradeFilter.Contains(grade))
				{
					Debug.Log($"Skipping grade {grade}");
					continue;
				}

				Debug.Log($"Creating tower for {grade} with {conceptsByGrade[grade].Count} concepts");
				var tower = Instantiate(towerPrefab, transform).GetComponent<Tower>();
				tower.transform.localPosition = new Vector3(i * 15, 0, 0);
				towers.Add(tower);

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
				{
					conceptsByGrade[concept.grade] = new List<Concept>();
				}

				conceptsByGrade[concept.grade].Add(concept);
			}
		}
	}
}