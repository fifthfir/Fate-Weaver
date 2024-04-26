using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
	private Vector2 lastPos;
	public float minHeight, maxHeight, leftMost, rightMost;

	// Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
			Mathf.Clamp(target.position.x, leftMost, rightMost),
			Mathf.Clamp(target.position.y, minHeight, maxHeight),
			transform.position.z);

		// float amountToMoveX = transform.position.x - lastXPos;
		Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

		lastPos = new Vector2(transform.position.x, transform.position.y);
    }
}
