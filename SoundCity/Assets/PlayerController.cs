using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public float speed;

    private Rigidbody2D rb;

    private float lastAngle = 0;

    public AudioClip[] stepSounds;
    public AudioSource stepSource;

    public float walkingTimeDiff;
    private float currWalkTimer;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        currWalkTimer = walkingTimeDiff;
	}
	
	// Update is called once per frame
	void Update () {


        //meta
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(0);
        }


        Vector2 inputVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        

        if (inputVec.magnitude < 0.2f)
        {
            rb.velocity = new Vector2();
            //Debug.Log("Unsufficient input");
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lastAngle - 90));
            return;
        }

        //walking sounds
        currWalkTimer -= Time.deltaTime;
        if (currWalkTimer <= 0)
        {
            currWalkTimer += walkingTimeDiff;
            stepSource.clip = stepSounds[(int)Random.Range(0, stepSounds.Length - 1)];
            stepSource.mute = false;
            stepSource.loop = false;
            stepSource.time = 0;
            stepSource.pitch = Random.Range(0.9f, 1.2f);
            stepSource.Play();
        }

        Vector3 directionPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(inputVec.x, inputVec.y));
        Vector2 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        directionPos.x -= object_pos.x;
        directionPos.y -= object_pos.y;
        float angle = Mathf.Atan2(directionPos.y, directionPos.x) * Mathf.Rad2Deg;
        lastAngle = angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        if (inputVec.magnitude > 1) inputVec = inputVec.normalized;
        rb.velocity = inputVec * speed;



    }
}
