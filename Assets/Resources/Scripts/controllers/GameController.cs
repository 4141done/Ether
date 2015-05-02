using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText hpBar;
	private bool gameOver;
	private bool restart;

	public int score;

	void Start ()
	{	
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		CollisionProps collisionProps = GameObject.FindWithTag ("Player").GetComponent<PlayerCollisionProps> ();
		SetHP (collisionProps.hitpoints, collisionProps.GetMaxHitPoints ());

		score = 0;
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true) //infinite loop
		{
			for (int i =0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " +score;
	}

	public void SetHP(int hitpoints, int maxHitpoints) {
		hpBar.text = "HP: " + hitpoints + "/" + maxHitpoints;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over Mother Fucker!";
		gameOver = true;
	}

}


