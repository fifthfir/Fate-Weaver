using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

	private Animator anim;
	private SpriteRenderer theSR;
	public Rigidbody2D theRB;

	// Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
		theSR = GetComponent<SpriteRenderer>();
		theRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

		bool moveHorizontal = true;
		bool moveUp = false;
		bool moveDown = false;

		if (horizontalInput < 0) {
			theSR.flipX = false;
		} else if (horizontalInput > 0) {
			theSR.flipX = true;
		} else {
			moveHorizontal = false;
		}

		if (verticalInput > 0) {
			moveUp = true;
		    moveDown = false;
		} else if (verticalInput < 0) {
			moveUp = false;
		    moveDown = true;
		} else {
			moveUp = false;
		    moveDown = false;
		}

		// Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f);
		// transform.position += moveDirection * moveSpeed * Time.deltaTime;

		theRB.velocity = new Vector2(moveSpeed * horizontalInput, moveSpeed * verticalInput);
		// No squash, good!

		// anim.SetFloat("moveSpeed", horizontalInput * horizontalInput + verticalInput * verticalInput);
		anim.SetBool("moveHorizontal", moveHorizontal);
		anim.SetBool("moveUp", moveUp);
		anim.SetBool("moveDown", moveDown);

		theRB.freezeRotation = true;

    }
}