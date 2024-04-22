using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    public Text textLabel;
    public Image Avatar;

	public TextAsset textFile;
	private int index;

	List<string> textList = new List<string>();

	public KeyCode talkKey = KeyCode.E;
	public KeyCode exitKey = KeyCode.Escape;

    void Start()
    {
		GetTextFromFile(textFile);
    }

	private void OnEnable() {
		textLabel.text = textList[index];
		index += 2;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(talkKey)) {
			if (index >= textList.Count) {
				gameObject.SetActive(false);
				index = 1;
				return;
			}

			textLabel.text = textList[index];
			index += 2;
		}
    }

	void GetTextFromFile(TextAsset file) {
		textList.Clear();
		index = 1;

		var lineData = file.text.Split('\n');
		foreach (var line in lineData) {
			textList.Add(line);
		}
	}
}
