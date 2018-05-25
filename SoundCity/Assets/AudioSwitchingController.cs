using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitchingController : MonoBehaviour {

    public Animator LightAnimator;
    public void switchTimeTo(int time){
        GlobalVariables.time = time;

        if (time == 0)
            LightAnimator.SetBool("Sepia", true);
        else
            LightAnimator.SetBool("Sepia", false);
    }
}
