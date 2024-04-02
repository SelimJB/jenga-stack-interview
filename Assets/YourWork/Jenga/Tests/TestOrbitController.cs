using UnityEngine;

namespace School.Jenga.Test
{
	public class TestOrbitController : MonoBehaviour
	{
		[SerializeField] private Camera camera;
		[SerializeField] private TowerOrbitController towerOrbitController;
		[SerializeField] private TestTowerCreator testTowerCreator;

		private void Start()
		{
			towerOrbitController = testTowerCreator.Tower.GetComponent<TowerOrbitController>();
		}

		private void Update()
		{
			if (!towerOrbitController) return;
			
			if (Input.GetKey(KeyCode.UpArrow))
				towerOrbitController.TranslateUp();

			if (Input.GetKey(KeyCode.DownArrow))
				towerOrbitController.TranslateDown();

			if (Input.GetKey(KeyCode.LeftArrow))
				towerOrbitController.RotateLeft();

			if (Input.GetKey(KeyCode.RightArrow))
				towerOrbitController.RotateRight();

			camera.transform.position = towerOrbitController.OrbitPosition;
			camera.transform.rotation = towerOrbitController.Orbit.rotation;
		}
	}
}