using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 2f;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D> ();
    }

	float horizontalDirection;
	float verticalDirection;
    float angle;

    void FixedUpdate()
    {
        horizontalDirection = (Input.GetKey("a")? -1f : 0f) + (Input.GetKey("d") ? 1f : 0f);
        verticalDirection = (Input.GetKey("w")? 1f : 0f) + (Input.GetKey("s") ? -1f : 0f);

		if (horizontalDirection != 0f || verticalDirection != 0f) {
			body.velocity = (Vector2.right * horizontalDirection + Vector2.up * verticalDirection) * speed;

            float angle = Mathf.Atan2(verticalDirection, horizontalDirection) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else {
            body.velocity = Vector2.zero;
        }
    }
}
