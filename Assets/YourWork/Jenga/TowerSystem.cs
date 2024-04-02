using UnityEngine;

namespace School.Jenga
{
	public class TowerSystem : MonoBehaviour
	{
		[SerializeField] private Tower tower;
		[SerializeField] private TowerLabel towerLabel;
		[SerializeField] private OrbitController orbitController;

		public Tower Tower => tower;
		public TowerLabel Label => towerLabel;
		public OrbitController OrbitController => orbitController;
	}
}