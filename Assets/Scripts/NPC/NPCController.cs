using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
	public NPCProfile npcProfile;

    public float moveSpeed;

	public Transform leftPoint, rightPoint;

	private bool movingRight;

	private Rigidbody2D theRB;
	public SpriteRenderer theSR;

	public float moveTime, waitTime;
	private float moveCount, waitCount;

	public static NPCController instance;

	public bool stopMoving;
	public bool hasTalked = false;

	private Animator anim;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		theRB = GetComponent<Rigidbody2D>();
		theSR = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

		leftPoint.parent = null;
		rightPoint.parent = null;
		movingRight = true;
		moveCount = moveTime;
		waitCount = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving)
		{
			if (moveCount > 0)
			{
				moveCount -= Time.deltaTime;
				anim.SetBool("isWalking", true);

				if (movingRight)
				{
					theSR.flipX = false;
					theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

					if (transform.position.x > rightPoint.position.x)
					{
						movingRight = false;
					}
				}
				else
				{
					theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
					theSR.flipX = true;

					if (transform.position.x < leftPoint.position.x)
					{
						movingRight = true;
					}
				}

				if (moveCount <= 0)
				{
					waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
					anim.SetBool("isWalking", false);
				}
			}
			else if (waitCount > 0)
			{
				anim.SetBool("isWalking", false);

				waitCount -= Time.deltaTime;
				theRB.velocity = new Vector2(0, theRB.velocity.y);

				if (waitCount <= 0)
				{
					moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
					anim.SetBool("isWalking", true);
				}

			}
		} else {
			theRB.velocity = new Vector2(0, 0);
			anim.SetBool("isWalking", false);
		}
    }
}
