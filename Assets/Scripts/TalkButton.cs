using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject talkButton;
    public GameObject hasTalkedButton;
    public GameObject talkUI;

	public KeyCode talkKey = KeyCode.E;
	public KeyCode exitKey = KeyCode.Escape;


	void Start()
    {
		talkButton.SetActive(false);
		hasTalkedButton.SetActive(false);
		talkUI.SetActive(false);
    }

	private void Update()
    {
        if ((Input.GetKeyDown(talkKey) || Input.GetButtonDown("PickUp")) &&
			(talkButton.activeSelf || hasTalkedButton.activeSelf))
        {
            talkUI.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
			if (!NPCController.instance.hasTalked) {
				talkButton.SetActive(true);
			} else {
				hasTalkedButton.SetActive(true);
			}

		}

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        talkButton.SetActive(false);
		hasTalkedButton.SetActive(false);
		talkUI.SetActive(false);
    }
}
