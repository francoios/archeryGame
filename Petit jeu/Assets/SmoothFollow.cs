using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public float smoothnes = 0.5f;
	public float zoom = -10;
	public Transform target;

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos = Vector3.Lerp (pos, target.position, smoothnes * Time.deltaTime);
		pos.z = zoom;
		transform.position = pos;
	}
}
