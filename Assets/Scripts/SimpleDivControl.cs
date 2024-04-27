using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDivControl : MonoBehaviour
{
    public KeyCode Key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            Debug.Log("toggling simple div panel");
            if (gameObject.activeSelf)
            {
                closeSimpleDivPanel();
            }

            else
            {
                openSimpleDivPanel();
            }
        }
    }

    // TODO IEnumerator animation/transisition effect
    void openSimpleDivPanel()
    {
        gameObject.SetActive(true);
    }

    void closeSimpleDivPanel()
    {
        gameObject.SetActive(false);
    }
}
