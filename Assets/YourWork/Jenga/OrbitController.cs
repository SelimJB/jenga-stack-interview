using UnityEngine;

namespace School.Jenga
{
	public class OrbitController : MonoBehaviour
	{
		[SerializeField] private Transform orbit;
		[SerializeField] private Transform center;
		[SerializeField] private float translationSpeed = 10f;
		[SerializeField] private float rotationSpeed = 20f;
		[SerializeField] private float scaleSpeedFactor = 2f;
		[SerializeField] private AnimationCurve scaleSpeedCurve;

		private float scaleSpeed;
		private Vector3 initialPivotPosition;
		private Vector3 finalPivotPosition;
		private Vector3 initialOrbitPosition;
		private Quaternion initialOrbitRotation;

		private float initialOrbitAltitude;
		private float finalOrbitAltitude;
		private float height = 20;

		private float Progress =>
			Mathf.Clamp((orbit.position.y - initialOrbitAltitude) / (finalOrbitAltitude - initialOrbitAltitude), 0f, 1f);

		private Vector3 pivot;
		public Transform Orbit => orbit;
		public Vector3 OrbitPosition => orbit.position;

		public void Initialize(float height)
		{
			this.height = height;

			initialOrbitPosition = orbit.position;
			initialOrbitRotation = orbit.rotation;

			initialPivotPosition = center.position + Vector3.up * height * (2.3f / 5f);
			finalPivotPosition = center.position + Vector3.up * height * (1.35f / 5f);

			initialOrbitAltitude = orbit.position.y;
			finalOrbitAltitude = height * 1.4f;

			Reset();
		}

		public void Reset()
		{
			Orbit.rotation = initialOrbitRotation;
			orbit.position = initialOrbitPosition;
			UpdateScaleSpeed(0f);
			UpdatePivotPosition(0f);
			orbit.LookAt(pivot);
		}


		private void UpdatePivotPosition(float progress)
		{
			pivot = Vector3.Lerp(initialPivotPosition, finalPivotPosition, progress);
		}

		private void UpdateScaleSpeed(float progress)
		{
			scaleSpeed = scaleSpeedCurve.Evaluate(progress) * scaleSpeedFactor;
		}

		public void TranslateUp()
		{
			if (Progress >= 1f) return;
			IncreaseDistance();
			orbit.Translate(Vector3.up * (Time.deltaTime * translationSpeed));
			UpdatePivotPosition(Progress);
			orbit.LookAt(pivot);
		}

		public void TranslateDown()
		{
			if (Progress <= 0f) return;
			DecreaseDistance();
			orbit.Translate(Vector3.down * (Time.deltaTime * translationSpeed));
			UpdatePivotPosition(Progress);
			orbit.LookAt(pivot);
		}

		public void RotateLeft()
		{
			orbit.RotateAround(pivot, Vector3.up, -rotationSpeed * Time.deltaTime);
			orbit.LookAt(pivot);
		}

		public void RotateRight()
		{
			orbit.RotateAround(pivot, Vector3.up, rotationSpeed * Time.deltaTime);
			orbit.LookAt(pivot);
		}

		private void IncreaseDistance()
		{
			UpdateScaleSpeed(Progress);
			var direction = (orbit.position - new Vector3(0, orbit.position.y, 0)).normalized;
			orbit.position += direction * (Time.deltaTime * scaleSpeed);
		}

		private void DecreaseDistance()
		{
			UpdateScaleSpeed(Progress);
			var direction = (orbit.position - new Vector3(0, orbit.position.y, 0)).normalized;
			orbit.position -= direction * (Time.deltaTime * scaleSpeed);
		}
	}
}