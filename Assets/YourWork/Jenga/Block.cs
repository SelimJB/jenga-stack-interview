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
	}
}