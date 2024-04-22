using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

	public KeyCode talkKey = KeyCode.E;
	public KeyCode exitKey = KeyCode.Escape;


	void Start()
    {
		Button.SetActive(false);
		talkUI.SetActive(false);
    }

	private void Update()
    {
        if ((Input.GetKeyDown(talkKey) || Input.GetButtonDown("PickUp")) && Button.activeSelf)
        {
            talkUI.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
			Button.SetActive(true);
		}

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
		talkUI.SetActive(false);
    }
}
