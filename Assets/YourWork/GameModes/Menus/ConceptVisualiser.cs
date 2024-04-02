using School.Data;
using TMPro;
using UnityEngine;

namespace School.GameModes.Menus
{
	public class ConceptVisualiser : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI GrandeAndDomain;
		[SerializeField] private TextMeshProUGUI Cluster;
		[SerializeField] private TextMeshProUGUI Description;

		public void Visualize(Concept concept)
		{
			GrandeAndDomain.text = $"{concept.grade} : {concept.domain}";
			Cluster.text = concept.cluster;
			Description.text = $"{concept.id} : {concept.standarddescription}";
		}
	}
}