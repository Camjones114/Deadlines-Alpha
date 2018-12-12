using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	[SerializeField]
	private player character;
	[SerializeField]
	private int numLives;
	[SerializeField]
	private int coinCount;
	[SerializeField]
	private int healthAmt;
	private HealthDisplay healthHolder;
	[SerializeField]
	private Text coinDisplayText;

	private Scene level;

	// Use this for initialization
	void Start()
	{
		healthHolder = FindObjectOfType<HealthDisplay>();
		character = FindObjectOfType<player>(); 
		if (character == null)
		{
			Debug.LogWarning("Character not found.");
			character = FindObjectOfType<player>();
		}
		//Todo: Find out how to save the scene of the level that was created procedurally,
		// so that it may be loaded upon death.
		numLives = character.getLives();
		if (coinDisplayText == null) {
			Debug.LogError ("coinDisplayText not assigned.");
		}
		FindObjectOfType<TimerDisplay>().setTimer(getTimeForLevel());
		coinCount = 0;
		coinDisplayText.text = "Coins: " + coinCount;
	}

	// Update is called once per frame
	void Update()
	{
		healthAmt = healthHolder.getHealth();
		coinDisplayText.text = "Coins: " + coinCount;

		if (Input.GetKeyDown(KeyCode.G))
		{
			decrementLives();
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			incrementLives();
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			addCoins(10);
			Debug.Log ("Coin Count: " + coinCount);
		}

		if (healthAmt <= 0)
		{
			decrementLives();
			healthHolder.recoverHealth(character.getHealth());
		}

		if (coinCount > 24)
		{
			incrementLives();
			coinCount -= 25;
		}
		if(coinCount  < 0)
		{
			coinCount = 0;
		}

		if (numLives < 0)
		{
			SceneManager.LoadScene("GameOver");
		}

	}

	float getTimeForLevel()
	{
		string playerType = FindObjectOfType<player>().GetType().ToString();
		switch (playerType)
		{
		case "athlete":
			return 270.0f;
			break;
		case "nerd":
			return 330.0f;
			break;
		case "procrastinator":
			return 300.0f;
			break;
		default:
			Debug.LogError("Player type not found, setting default time.");
			return 1000.0f;
			break;
		}
	}

	public void addCoins(int amt)
	{
		coinCount += amt;
	}

	public void decrementLives()
	{
		numLives--;
		FindObjectOfType<LivesDisplay>().updateLives();
	}

	public void incrementLives()
	{
		numLives++;
		FindObjectOfType<LivesDisplay>().updateLives();
	}

	public int getNumLives()
	{
		return numLives;
	}
}