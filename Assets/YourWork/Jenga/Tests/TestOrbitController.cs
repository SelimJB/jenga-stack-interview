using UnityEngine;

namespace School.Jenga.Test
{
	public class TestOrbitController : MonoBehaviour
	{
		[SerializeField] private Camera controlCamera;
		[SerializeField] private OrbitController orbitController;
		[SerializeField] private TestTowerCreator testTowerCreator;

		private void Start()
		{
			orbitController = testTowerCreator.Tower.GetComponent<OrbitController>();
			orbitController.Initialize(testTowerCreator.Tower.Height);
		}

		private void Update()
		{
			if (!orbitController) return;
			
			if (Input.GetKey(KeyCode.UpArrow))
				orbitController.TranslateUp();

			if (Input.GetKey(KeyCode.DownArrow))
				orbitController.TranslateDown();

			if (Input.GetKey(KeyCode.LeftArrow))
				orbitController.RotateLeft();

			if (Input.GetKey(KeyCode.RightArrow))
				orbitController.RotateRight();

			controlCamera.transform.position = orbitController.OrbitPosition;
			controlCamera.transform.rotation = orbitController.Orbit.rotation;
		}
	}
}