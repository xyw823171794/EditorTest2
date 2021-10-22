using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUIAnimation : MonoBehaviour
{
    public Text loadingText;
    private string loadingStr = "Loading";
    private int dotCount;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        time = 0;
        loadingText.text = loadingStr;
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0.3f)
        {
            time = 0;
            loadingText.text = loadingText.text + ".";
            dotCount++;
            if (dotCount > 3)
            {
                dotCount = 0;
                loadingText.text = loadingStr;
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
