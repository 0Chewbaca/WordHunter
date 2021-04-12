using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Arranger : MonoBehaviour
{
    public GameObject Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9;
    public TextAsset textJson;
    int unit;
    int max_unit_level;

    List<GameObject> Level_Buttons;

    [System.Serializable]
    public class Levels
    {
        public int Seviye;
        public string Kelime;
        public int Unit;
        public string Turkce;
    }

    [System.Serializable]
    public class Word_List
    {
        public Levels[] Levels;
    }

    public Word_List myWord_List = new Word_List();

    public void Load_JSON()
    {
        myWord_List = JsonUtility.FromJson<Word_List>(textJson.text);

        foreach (Levels item in myWord_List.Levels)
        {
            if (item.Unit == unit)
            { 

                if (item.Seviye > max_unit_level)
                {
                    max_unit_level = item.Seviye;
                }
            }
            

        }
    }

    void Start()
    {
        unit = PlayerPrefs.GetInt("unit");
        Load_JSON();
        Level_Buttons = new List<GameObject>() {Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9 };

        for (int i = 0; i < max_unit_level; i++)
        {
            Level_Buttons[i].SetActive(true);
        }
    }

}
