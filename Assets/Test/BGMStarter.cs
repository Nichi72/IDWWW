using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStarter : MonoBehaviour {

    SoundManager soundManager;

    public AudioClip BGMClip;

    private void Awake()
    {
        soundManager = SoundManager._instence;
    }

    // Use this for initialization
    void Start () {
        soundManager.playBGM(BGMClip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
