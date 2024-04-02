using System.Collections.Generic;
using System.Linq;
using School.Jenga;
using UnityEngine;

namespace School.GameModes
{
	public class TestMyStackController : MonoBehaviour
	{
		private List<TowerSystem> towerSystems;
		private TowerSystem selectedTowerSystem;
		private TestMyStackState state = TestMyStackState.TowerSelectedView;

		private TowerSystem SelectedTowerSystem => selectedTowerSystem;

		public void Initialise(List<TowerSystem> towers)
		{
			this.towerSystems = towers;
			selectedTowerSystem = towers.First();
		}

		public void Reset()
		{
			if (state == TestMyStackState.BroadView)
			{
				foreach (var ts in towerSystems)
				{
					ts.Tower.Reset();
				}
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
				{
					ts.Tower.ApplyBlockBehaviors();
				}
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

		private void SelectTower(TowerSystem tower) { }

		public void ToggleState()
		{
			state = state == TestMyStackState.BroadView ? TestMyStackState.TowerSelectedView : TestMyStackState.BroadView;
		}
	}

	public enum TestMyStackState
	{
		BroadView,
		TowerSelectedView
	}
}