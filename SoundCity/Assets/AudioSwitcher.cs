using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour {

    int currTime = 1;

    public AudioSource[] audiosources;

	// Use this for initialization
	void Start () {
        currTime = GlobalVariables.time;

        for(int i=0; i < audiosources.Length; i++)
        {
            if (i != currTime)
            {
                audiosources[i].mute = true;
            }
            else
            {
                audiosources[i].mute = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (currTime != GlobalVariables.time)
        {
            currTime = GlobalVariables.time;
            for (int i = 0; i < audiosources.Length; i++)
            {
                if (i != currTime)
                {
                    audiosources[i].mute = true;
                }
                else
                {
                    audiosources[i].mute = false;
                }
            }
        }

	}
}
