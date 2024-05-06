using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButtonController : MonoBehaviour
{
    public Transform target;
	private Vector2 lastPos;

	// Start is called before the first frame update
    void Start()
    {
		lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
			target.position.x,
			transform.position.y,
			transform.position.z);

		// float amountToMoveX = transform.position.x - lastXPos;
		Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, 0);

		lastPos = new Vector2(transform.position.x, transform.position.y);
    }
}
