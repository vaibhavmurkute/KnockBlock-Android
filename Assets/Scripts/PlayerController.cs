using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float speed = 13;

	public event System.Action onPlayerDeath;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		float inputX = Input.GetAxisRaw ("Horizontal");
		float inputX = Input.acceleration.x;
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag == "Falling Block"){
			FindObjectOfType<GameOver>().onGameOver();
	/*		if(onPlayerDeath != null){
				onPlayerDeath();
			} */
			Destroy(gameObject);
		}
	}
}
