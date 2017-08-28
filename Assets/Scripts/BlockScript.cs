using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public float speed;
	public Vector2 speedMaxMin;
	float visibleHeightThreshold;

	void start(){
		speed = Mathf.Lerp (speedMaxMin.y, speedMaxMin.x, Difficulty.getDifficultyPercentage ());

//		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}

	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime, Space.Self);

		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
		if(transform.position.y < visibleHeightThreshold){
			Destroy(gameObject);
		} 

	}

	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag == "Bullet"){
			Destroy(gameObject);
			GameOver.score += 1; 
		}
	}
}
