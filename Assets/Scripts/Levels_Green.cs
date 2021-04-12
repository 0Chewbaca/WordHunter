using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels_Green : MonoBehaviour
{
    Image color;
    string word;
    string hello;
    int unit;

    void Start()
    {
        unit = PlayerPrefs.GetInt("unit");
        color = GetComponent<Image>();
        color.color = Color.white;
        word = gameObject.name;
        hello = unit.ToString() + word;

        if (PlayerPrefs.HasKey(hello))
        {

            if (PlayerPrefs.GetInt(hello) == 1)
            {
                color.color = Color.green;
            }
        }
    }

}
