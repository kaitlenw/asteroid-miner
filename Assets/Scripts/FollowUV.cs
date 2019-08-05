using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

	public float parallax = 2f;

	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / transform.localScale.x / parallax;
		offset.y = transform.position.y / transform.localScale.y / parallax;

		mat.mainTextureOffset = offset;

	}

}
