using UnityEngine;

namespace School.Jenga
{
	public class TestTowerCreator : MonoBehaviour
	{
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] private int blockCount = 50;

		private void Start()
		{
			var tower = Instantiate(towerPrefab, transform).GetComponent<Tower>();
			var blocks = tower.CreateRandomBlocks(blockCount);
			tower.CreateTower(blocks);
			tower.PositionBlocks();
		}
	}
}