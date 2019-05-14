using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponLabel3 : MonoBehaviour
{
    TextMeshProUGUI weaponLabel;
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        weaponLabel = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt("SwordLevel");
        weaponLabel.SetText(level.ToString());
    }
}
