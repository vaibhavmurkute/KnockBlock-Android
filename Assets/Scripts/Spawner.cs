using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlock;
	public GameObject bullet;
	GameObject player;
	Vector2 screenSize;
	public Vector2 secondsBetweenSpawnMaxMin;
	float nextSpawnTime;
	public Vector2 blockScaleLimit;
	public float blockAngleMax;
	float bulletStartOffset;

	void Start () {
		screenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
		player = GameObject.FindGameObjectWithTag ("Player");
		bulletStartOffset = player.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > nextSpawnTime){
			nextSpawnTime = Time.timeSinceLevelLoad + Mathf.Lerp(secondsBetweenSpawnMaxMin.y,secondsBetweenSpawnMaxMin.x,Difficulty.getDifficultyPercentage());

			float blockScale = Random.Range(blockScaleLimit.x,blockScaleLimit.y);
			float blockAngle = Random.Range(-blockAngleMax, blockAngleMax);
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenSize.x, screenSize.x), screenSize.y + blockScale);
			GameObject newBlock = (GameObject) Instantiate (fallingBlock, spawnPosition, Quaternion.Euler(Vector3.forward * blockAngle));
			newBlock.transform.localScale = Vector2.one * blockScale;
		}

		if(Input.GetTouch(0).phase == TouchPhase.Began){
			if(player.activeSelf){
				Vector2 playerPos = new Vector2 (player.transform.position.x, player.transform.position.y + bulletStartOffset);
				Instantiate (bullet, playerPos, Quaternion.identity);
			}
		}
	}
}
