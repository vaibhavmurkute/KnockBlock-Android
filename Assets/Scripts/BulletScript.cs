using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float speed = 15;
	float visibleHeightThreshold;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.y;
		if(transform.position.y > visibleHeightThreshold){
			Destroy(gameObject);
		} 
	}
}
