using UnityEngine;

namespace School.Jenga.Test
{
	public class TestTowerCreator : MonoBehaviour
	{
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] private int blockCount = 50;

		private Tower tower;

		public Tower Tower => tower;

		private void Awake()
		{
			tower = Instantiate(towerPrefab, transform).GetComponent<Tower>();
			var blocks = tower.CreateRandomBlocks(blockCount);
			tower.CreateTower(blocks);
			tower.PositionBlocks();
		}
	}
}