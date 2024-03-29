using UnityEngine;

namespace Jenga
{
	// WIP : Remove and only use BlockProfile ?
	[RequireComponent(typeof(BlockProfile))]
	public class Block : MonoBehaviour
	{
		[SerializeField] private BlockProfile blockProfile;

		private void Start()
		{
			Debug.Log(blockProfile.Type);
		}

		public float Length => transform.localScale.z;
		public float Width => transform.localScale.x;
		public float Height => transform.localScale.y;
		public bool AreProportionsCorrect => Width * 3 < Length;
		public float EmptySpaceWidth => Length - Width * 3;
	}
}