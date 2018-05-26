using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcherMultiple : MonoBehaviour {

    int currTime = 1;

    public AudioSource[] pastSources;
    public AudioSource[] presentSources;

    // Use this for initialization
    void Start()
    {
        currTime = GlobalVariables.time;

        SetTime();
    }

    // Update is called once per frame
    void Update()
    {

        if (currTime != GlobalVariables.time)
        {
            currTime = GlobalVariables.time;

            SetTime();
        }

    }

    void SetTime()
    {
        bool setPast = currTime == 1 ? true : false;

        for (int i = 0; i < pastSources.Length; i++)
        {
            pastSources[i].mute = setPast;
        }

        for (int i = 0; i < presentSources.Length; i++)
        {
            presentSources[i].mute = !setPast;
        }
    }
}
