using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour {

    private MusicManager musicManager;
	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
