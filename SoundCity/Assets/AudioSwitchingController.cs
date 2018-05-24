using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitchingController : MonoBehaviour {

    public void switchTimeTo(int time){
        GlobalVariables.time = time;
    }
}
