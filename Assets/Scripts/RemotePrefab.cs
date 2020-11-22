using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemotePrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;
    int num = 0;
    private void Start()
    {
        txt.text = num.ToString();
        StartCoroutine(ShowTiming());
    }

    IEnumerator ShowTiming()
    {
        while (num >= 0)
        {
            num++;
            txt.text = num.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}

