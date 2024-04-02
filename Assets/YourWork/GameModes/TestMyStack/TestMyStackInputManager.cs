using UnityEngine;

namespace School.GameModes
{
	// Basic input manager -> TODO : improve using the new input system
	public class TestMyStackInputManager : MonoBehaviour
	{
		[SerializeField] TestMyStackController controller;

		public void Update()
		{
			if (Input.GetKey(KeyCode.UpArrow))
				controller.OrbitController.TranslateUp();

			if (Input.GetKey(KeyCode.DownArrow))
				controller.OrbitController.TranslateDown();

			if (Input.GetKey(KeyCode.LeftArrow))
				controller.OrbitController.RotateLeft();

			if (Input.GetKey(KeyCode.RightArrow))
				controller.OrbitController.RotateRight();

			if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape))
				controller.ToggleState();

			if (Input.GetKeyDown(KeyCode.Return))
			{
				if (controller.IsTriggered)
					controller.Reset();
				else
					controller.TestMyStack();
			}

			if (controller.State == TestMyStackState.TowerSelectedView)
			{
				if (Input.GetKeyDown(KeyCode.Tab))
					controller.SelectNextTower();
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.Tab))
					controller.ToggleState();
			}
		}
	}
}