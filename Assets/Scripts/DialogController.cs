using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    public Text textLabel;
    public Image Avatar;

	public Sprite face01, face02;

	public TextAsset textFile;
	private int index;
	private PlayerController thePC;

	List<string> textList = new List<string>();

	public KeyCode talkKey = KeyCode.E;
	public KeyCode exitKey = KeyCode.Escape;

    void Start()
    {
		GetTextFromFile(textFile);
    }

	private void OnEnable() {
		PlayerController.instance.stopInput = true;

		index = 0;

		switch(textList[index].Trim().ToString()) {
			case "A":
				Avatar.sprite = face01;
				index++;
				break;
			case "B":
				Avatar.sprite = face02;
				index++;
				break;
		}

		textLabel.text = textList[index];
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(talkKey) || Input.GetButtonDown("PickUp")) {

			index++;

			if (index >= textList.Count) {
				endDialog();
				return;
			}

			switch(textList[index].Trim().ToString()) {
				case "A":
					Avatar.sprite = face01;
					index++;
					break;
				case "B":
					Avatar.sprite = face02;
					index++;
					break;
			}

			// Take it for granted that A/B must followed by some sentences,,,,

			textLabel.text = textList[index];
		}

		if (Input.GetKeyDown(exitKey)) {
			endDialog();
			return;
		}
    }

	void GetTextFromFile(TextAsset file) {
		textList.Clear();
		index = 0;

		var lineData = file.text.Split('\n');
		foreach (var line in lineData) {
			textList.Add(line);
		}
	}

	void endDialog() {
		PlayerController.instance.stopInput = false;
		gameObject.SetActive(false);
		index = 0;
	}
}
