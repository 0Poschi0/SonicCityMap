using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 inputVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        if (inputVec.magnitude < 0.2f)
        {
            rb.velocity = new Vector2();
            return;
        }

        Vector3 directionPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(inputVec.x, inputVec.y));
        Vector2 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        directionPos.x -= object_pos.x;
        directionPos.y -= object_pos.y;
        float angle = Mathf.Atan2(directionPos.y, directionPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        if (inputVec.magnitude > 1) inputVec = inputVec.normalized;
        rb.velocity = inputVec * speed;
	}
}
