using System;
using UnityEngine;

namespace School.Data
{
	public static class JsonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			var wrapperJson = "{ \"Items\": " + json + "}";
			var wrapper = JsonUtility.FromJson<Wrapper<T>>(wrapperJson);
			return wrapper.Items;
		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}
	}
}