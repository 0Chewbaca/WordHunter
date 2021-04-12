using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class green_maker : MonoBehaviour
{
    Image color;
    string word;
    public TextAsset textJson;
    int max_unit_level;


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

    public Word_List your_word_list = new Word_List();


    public int Load_JSON(int _unit)
    {
        int maximum_unit = 0;

        your_word_list = JsonUtility.FromJson<Word_List>(textJson.text);


        foreach (Levels item in your_word_list.Levels)
        {
            if (item.Unit == _unit)
            {

                if (item.Seviye > maximum_unit)
                {
                    maximum_unit = item.Seviye;
                }
            }
        }

        return maximum_unit;

    }


    void Start()
    {

        color = GetComponent<Image>();
        color.color = Color.white;
        word = gameObject.name;

        max_unit_level = Load_JSON(int.Parse(word));

        
        
        int control = 0;

        for (int i = 1; i <= max_unit_level; i++)
        {
            if (PlayerPrefs.GetInt(word + i.ToString()) == 1)
            {
                control = control + 1 ;
            }
        }

        

        if (control == max_unit_level)
        {
            color.color = Color.green;
        }

    }
}