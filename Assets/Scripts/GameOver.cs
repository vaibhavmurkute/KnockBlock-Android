using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text scoreText;
	public static int score = 0;
	bool gameOver;


	void start(){
		print ("inside Start");
		FindObjectOfType<PlayerController> ().onPlayerDeath += onGameOver;
	}
	
	// Update is called once per frame
	void Update () {
//		if(playerController.activeSelf){
//			FindObjectOfType<PlayerController> ().onPlayerDeath += onGameOver;
//		}

		if(gameOver){
			if(Input.GetTouch(0).phase == TouchPhase.Moved){
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
				score = 0;
			}
		}
	}

	public void onGameOver(){
		gameOverScreen.SetActive(true);
		gameOver = true;
//		scoreText.text = Time.timeSinceLevelLoad.ToString();
		scoreText.text = score.ToString();
	}
}
