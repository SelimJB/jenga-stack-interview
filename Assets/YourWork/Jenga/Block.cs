using School.Data;
using UnityEngine;

namespace School.Jenga
{
	[RequireComponent(typeof(BlockProfile))]
	public class Block : MonoBehaviour
	{
		[SerializeField] private BlockProfile blockProfile;

		private Concept concept;

		public BlockProfile Profile => blockProfile;

		public Concept Concept
		{
			get
			{
				if (concept == null)
				{
					Debug.LogWarning("Concept not initialized, creating an empty one");
					concept = new Concept();
				}

				return concept;
			}
			set => concept = value;
		}

		public float Length => transform.localScale.z;
		public float Width => transform.localScale.x;
		public float Height => transform.localScale.y;
		public bool AreProportionsCorrect => Width * 3 < Length;
		public float EmptySpaceWidth => Length - Width * 3;
	}
}