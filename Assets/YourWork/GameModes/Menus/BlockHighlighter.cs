using School.Jenga;
using UnityEngine;

namespace School.GameModes.Menus
{
	public class BlockHighlighter : MonoBehaviour
	{
		[SerializeField] private Camera camera;
		[SerializeField] private RectTransform panel;
		[SerializeField] private Canvas canvas;
		[SerializeField] private ConceptVisualiser conceptVisualiser;

		private Block hoveredBlock;

		private void Update()
		{
			var ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				var block = hit.transform.GetComponent<Block>();
				if (block != hoveredBlock && block)
				{
					hoveredBlock = block;
					panel.gameObject.SetActive(true);
					PositionPanelOnCanvas(block.transform.position);
					conceptVisualiser.Visualize(block.Concept);
				}
			}
			else
			{
				hoveredBlock = null;
				// panel.gameObject.SetActive(false);
			}
		}

		private void PositionPanelOnCanvas(Vector3 worldPosition)
		{
			var screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPoint, canvas.worldCamera,
				out Vector2 canvasPosition);
			panel.anchoredPosition = canvasPosition;
		}
	}
}