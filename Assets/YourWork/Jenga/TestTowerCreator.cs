using UnityEngine;

namespace School.Jenga
{
	public class TestTowerCreator : MonoBehaviour
	{
		[SerializeField] private GameObject towerPrefab;

		private void Start()
		{
			var tower = Instantiate(towerPrefab, transform).GetComponent<Tower>();
			var blocks = tower.CreateRandomBlocks(50);
			tower.CreateTower(blocks);
			tower.PositionBlocks();
		}
	}
}