using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Random = System.Random;
using System.Linq;

public class word_loader : MonoBehaviour
{
    public int maxLevelForUnit = 0;
    public TextAsset textJson;
    public Text english, turkish;
    public Text unit_finding;
    int unit;
    



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
                english.text = english.text + "\n\n" + item.Kelime + " :";
                turkish.text = turkish.text + "\n\n" + item.Turkce;
            }

        }
        
    }


    void Start()
    {
        
        unit = PlayerPrefs.GetInt("unit");
        unit_finding.text = "UNIT " + unit.ToString();
        Load_JSON();
    }
}
