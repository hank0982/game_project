using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    TextMeshProUGUI scoreLabel;
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt("level") / 5;
        scoreLabel.SetText("Level " + level);
    }
}
