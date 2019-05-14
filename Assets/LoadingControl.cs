using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingControl : MonoBehaviour
{
    public GameObject panel;
    public GameObject loadingObj;
    public Slider slider;

    AsyncOperation async;

    public void LoadingScreen(int level)
    {
        StartCoroutine(StartLoading(level));
    }

    IEnumerator StartLoading(int level)
    {
        panel.SetActive(false);
        loadingObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(level);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    
}
