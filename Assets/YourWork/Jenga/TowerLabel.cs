using TMPro;
using UnityEngine;

namespace School.Jenga
{
	public class TowerLabel : MonoBehaviour
	{
		[SerializeField] public TMP_Text textMesh;

		public void SetText(string text)
		{
			textMesh.text = text;
		}
	}
}