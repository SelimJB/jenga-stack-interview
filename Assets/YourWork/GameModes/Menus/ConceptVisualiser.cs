using School.Data;
using TMPro;
using UnityEngine;

namespace School.GameModes.Menus
{
	public class ConceptVisualiser : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI GradeLevel;
		[SerializeField] private TextMeshProUGUI Domain;
		[SerializeField] private TextMeshProUGUI Cluster;
		[SerializeField] private TextMeshProUGUI Description;

		public void Visualize(Concept concept)
		{
			GradeLevel.text = concept.grade;
			Domain.text = concept.domain;
			Cluster.text = concept.cluster;
			Description.text = $"{concept.id} : {concept.standarddescription}";
		}
	}
}