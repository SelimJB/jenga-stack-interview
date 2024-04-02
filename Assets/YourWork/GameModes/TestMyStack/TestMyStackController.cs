using System.Collections.Generic;
using System.Linq;
using School.Jenga;
using UnityEngine;

namespace School.GameModes
{
	public class TestMyStackController : MonoBehaviour
	{
		[SerializeField] private Camera controlCamera;
		[SerializeField] private OrbitController broadViewOrbitController;

		private List<TowerSystem> towerSystems;
		private TowerSystem selectedTowerSystem;
		private TestMyStackState state = TestMyStackState.TowerSelectedView;

		public TowerSystem SelectedTowerSystem => selectedTowerSystem;
		public TestMyStackState State => state;

		public bool IsTriggered =>
			state == TestMyStackState.BroadView
				? towerSystems.All(ts => ts.Tower.IsTriggered)
				: selectedTowerSystem.Tower.IsTriggered;

		public OrbitController OrbitController
			=> state == TestMyStackState.BroadView ? broadViewOrbitController : selectedTowerSystem.OrbitController;

		public void Update()
		{
			controlCamera.transform.position = OrbitController.OrbitPosition;
			controlCamera.transform.rotation = OrbitController.Orbit.rotation;
		}

		public void Initialise(List<TowerSystem> towerSystems)
		{
			this.towerSystems = towerSystems;
			selectedTowerSystem = towerSystems.First();
			var biggestTowerHeight = towerSystems.OrderByDescending(ts => ts.Tower.Height).First().Tower.Height;
			broadViewOrbitController.Initialize(biggestTowerHeight);
		}

		public void Reset()
		{
			if (state == TestMyStackState.BroadView)
			{
				foreach (var ts in towerSystems)
					ts.Tower.Reset();
			}
			else
			{
				selectedTowerSystem.Tower.Reset();
			}
		}

		public void TestMyStack()
		{
			if (state == TestMyStackState.BroadView)
			{
				foreach (var ts in towerSystems)
					ts.Tower.ApplyBlockBehaviors();
			}
			else
			{
				selectedTowerSystem.Tower.ApplyBlockBehaviors();
			}
		}

		public void SelectNextTower()
		{
			var index = towerSystems.IndexOf(selectedTowerSystem);
			index = (index + 1) % towerSystems.Count;
			selectedTowerSystem = towerSystems[index];
			SelectTower(selectedTowerSystem);
		}

		public void SelectPreviousTower()
		{
			var index = towerSystems.IndexOf(selectedTowerSystem);
			index = (index - 1 + towerSystems.Count) % towerSystems.Count;
			selectedTowerSystem = towerSystems[index];
			SelectTower(selectedTowerSystem);
		}

		private void SelectTower(TowerSystem tower)
		{
			tower.OrbitController.Reset();
		}

		public void ToggleState()
		{
			OrbitController.Reset();
			state = state == TestMyStackState.BroadView ? TestMyStackState.TowerSelectedView : TestMyStackState.BroadView;
		}
	}

	public enum TestMyStackState
	{
		BroadView,
		TowerSelectedView
	}
}