using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class LanguageSwitchController : MonoBehaviour
{
    public bool isEN;

    // Start is called before the first frame update
    void Start()
    {
        isEN = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Chinese: 0, English: 1
    public void SwitchLanguage()
	{
		Debug.Log("Switch Language");
        isEN = !isEN;

        if (isEN) {
            StartCoroutine(SetLocale(1));
        } else {
            StartCoroutine(SetLocale(0));
        }
        
	}

    // CN: 0; EN: 1
    IEnumerator SetLocale(int id)
	{
		Debug.Log("Switch Language");
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
	}
}
