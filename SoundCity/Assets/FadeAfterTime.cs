using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAfterTime : MonoBehaviour {

    public SpriteRenderer spriteToFade;
    public float fadeStartTime;
    public float fadeDuration;

    float startTime;
    bool begunFade = false;


	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!begunFade)
        {
            if (Time.time >= fadeStartTime)
            {
                begunFade = true;
            }
        }
        else
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;

            float newA = Mathf.Lerp(1, 0, t);

            spriteToFade.color = new Color(spriteToFade.color.r, spriteToFade.color.g, spriteToFade.color.b, newA);

            if (Time.time > fadeStartTime + fadeDuration)
            {
                Destroy(gameObject);
            }
        }
	}
}
