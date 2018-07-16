using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelTime = 60f;
    private AudioSource audioSource;
    private bool levelOver;
    private GameObject winLabel;
    private Text winText;
    private LevelManager levelManager;
    private float timeRemaining;
    private Slider gameTime;
	// Use this for initialization
	void Start ()
    {
        gameTime = GetComponent<Slider>();
        gameTime.maxValue = levelTime;
        gameTime.minValue = 0f;
        levelOver = false;
        FindWin();
        winText = winLabel.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        levelManager = FindObjectOfType<LevelManager>();
        
    }

    private void FindWin()
    {
        winLabel = GameObject.Find("YouWon");
        if (!winLabel)
        {
            Debug.Log("Please add you win object");
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        
        if(gameTime.value>= levelTime && !levelOver)
        {
            levelOver = true;
            winText.enabled = true; 
            audioSource.Play();

            Invoke("LoadNextLevel", audioSource.clip.length);                   
        }
        gameTime.value += Time.deltaTime * 1;
    }
    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
