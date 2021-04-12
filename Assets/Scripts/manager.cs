using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Random = System.Random;
using System.Linq;
using Unity.Mathematics;

public class manager : MonoBehaviour
{    
    public  GameObject menuButton;
    public Text unit_TEXT;
    public Text level_TEXT;

    [SerializeField]
    int random_int_for_reversing;
    [SerializeField]
    int random_int_for_selecting;
    
    int screen_width = Screen.width;
    
    int screen_height = Screen.height;
    
    int Redmi_7_height = 2340;
    
    int Redmi_7_width = 1080;
    
    float height_To_Be;
    
    float width_To_Be;
    int letters_index = 24;
    public TextAsset textJson;
    int level;
    int unit;
    int max_unit_level;
    string[] dictionary = new string[5];
    public bool pressed = false;
    public Text puan_txt;
    public Text yazi_txt;
    List<String> pressed_buttons;
    string word = null;
    public Text letters_Eng, letters_Tr;

    int found_words = 0;
    int puan;
    public GameObject buttons;
    int highScore;
    List<GameObject> pressedObjects;
    public Text dictionary_length;
    
    int length = 0;
    public GameObject Kalan_Kelimeler;
    public GameObject letterPrefab;
    public GameObject Parent;
    bool level_finished;
    public Text level_Text;
    public Text unit_Text;
    int[,] letters_traverse_indexes = new int[3, 25] 
    {
        {
            7,13,18,19,14,
            8,2,1,6,12,
            17,11,16,21,22,
            23,24,25,20,15,
            9,5,10,4,3
        },

        {
            24,25,19,23,18,
            14,20,15,9,13,
            17,21,22,16,11,
            7,2,1,6,12,
            8,3,4,10,5
        },

        {
            1,7,13,9,3,
            2,8,14,19,18,
            12,6,11,17,21,
            16,22,23,24,25,
            20,15,10,4,5
        }
    };
    int _length;

    string[] letters = new string[25];

    [System.Serializable]
    public class Levels
    {
        public int Seviye;
        public string Kelime;
        public int Unit;
        public string Turkce;
    }
    
    [System.Serializable]
    public class WordList
    {
        public Levels[] Levels;
    }
    public WordList myWordList = new WordList();

    public void Load_JSON()
    {
        Random rnd = new Random();
        random_int_for_reversing = rnd.Next(0,2);
        random_int_for_selecting = rnd.Next(0,3);
        int ordinary_number = 0;

        myWordList = JsonUtility.FromJson<WordList>(textJson.text);
        
        foreach (Levels item in myWordList.Levels)
        {
            if(item.Unit == unit)
            {
                if (item.Seviye == level)
                {
                    for (int i = 0; i < item.Kelime.Length; i++)
                    {

                        if (random_int_for_reversing == 1)
                        {
                            letters[letters_traverse_indexes[random_int_for_selecting, ordinary_number] -1] = Char.ToString(item.Kelime[i]);
                        }
                        else
                        {
                            letters[letters_traverse_indexes[random_int_for_selecting, letters_index] -1] = Char.ToString(item.Kelime[i]);
                        }
                        letters_index--;

                        ordinary_number++;
                    }
                    length++;
                    _length = length;
                    letters_Eng.text = letters_Eng.text + "\n\n" + item.Kelime + " :";
                    letters_Tr.text = letters_Tr.text + "\n\n" + item.Turkce;
                }
                if (item.Seviye > max_unit_level)
                {
                    max_unit_level = item.Seviye;
                }
            }
        }
    }

    void Start()
    {
        height_To_Be = (float)screen_height / Redmi_7_height;
        width_To_Be = (float)screen_width / Redmi_7_width;

        level_finished = false;
        buttons.SetActive(false);
        puan = 0;
        pressed = false;
        pressed_buttons = new List<String>();
        pressedObjects = new List<GameObject>();

        if (!PlayerPrefs.HasKey("1"))
        {
            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
        }

        if (!PlayerPrefs.HasKey("11"))
        {
            for (int i = 1; i < 11; i++)
            {
                for (int d = 1; d < 10; d++)
                {
                    PlayerPrefs.SetInt((i*10+d).ToString(), 0);
                }
            }
        }

        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
            level = 1;

        } else
        {
            if (PlayerPrefs.GetInt("level") == 0)
            {
                level = 1;
            }
            else
            {
                level = PlayerPrefs.GetInt("level");
            }
            
        }

        if (!PlayerPrefs.HasKey("unit"))
        {
            PlayerPrefs.SetInt("unit", 1);
            unit = 1;

        }
        else
        {
            if (PlayerPrefs.GetInt("unit") == 0)
            {
                unit = 1;
            }
            else
            {
                unit = PlayerPrefs.GetInt("unit");
            }

        }

        
        Load_JSON();
        AddWord();
        Dicitonary_Arrangement();
        

        level_Text.text = level.ToString();
        unit_Text.text = unit.ToString();

        level_TEXT.gameObject.SetActive(true);
        unit_TEXT.gameObject.SetActive(true);
        level_Text.gameObject.SetActive(true);
        unit_Text.gameObject.SetActive(true);
    }

    public void Dicitonary_Arrangement ()
    {
        int i = 0;

        foreach (Levels item in myWordList.Levels)
        {
            if (item.Seviye == level && item.Unit == unit)
            {
                dictionary[i] = item.Kelime;
                i++;
            }
        }
    }

    void AddWord ()
    {
        float leftcorner_X, leftcorner_Y;

        var random = new Random();

        // 125
        leftcorner_X = 125f * width_To_Be;
        // 1814
        leftcorner_Y = 1750f * height_To_Be;

        List<int> randomList = new List<int>();
        int c = 0;

        for (int i = 0; i < 5; i++)
        {

            for (int a = 0; a < 5; a++)
            {
                New_Letter(leftcorner_X, leftcorner_Y, letters[c]);
                leftcorner_X += 200 * width_To_Be;
                c++;
            }

            leftcorner_Y -= 345 * height_To_Be;
            leftcorner_X = 125f * width_To_Be;
        }
    }

    void New_Letter (float Xpos, float Ypos, string Letter)
    {
        Vector2 newPos = Vector2.zero;
        newPos = new Vector2(Xpos, Ypos);
        var newLetter = Instantiate(letterPrefab, newPos, Quaternion.identity);
        newLetter.transform.localScale = new Vector2(width_To_Be * (float) 1.0, (float) 4.7 * height_To_Be);
        newLetter.transform.SetParent(Parent.transform);   

        newLetter.transform.Find("Text").GetComponent<Text>().text = Letter;
        newLetter.name = Letter;
    }
    public void create_pressed_buttons (String letter, GameObject objectPress)
    {

        pressed_buttons.Add(letter);
        pressedObjects.Add(objectPress);
        word = null;
        
        foreach (String letters in pressed_buttons)
        {
            word = word + letters;
            yazi_txt.text = word;
        }
        

    }

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
            pressed = true;

        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            create_words();
        }
        puan_txt.text = puan.ToString();

        dictionary_length.text = length.ToString();
    }

    void create_words ()
    {
        

        foreach (string words in dictionary)
        {

            if (words == word && word != null)
            {

                puan = puan + 100;
                found_words++;
                length--;
                foreach (GameObject button in pressedObjects)
                {
                    button.GetComponent<button>().died = true;
                }
            }

        }

        pressed_buttons.Clear();
        pressedObjects.Clear();
        word = null;
        yazi_txt.text = "";

        if (found_words == _length && !level_finished)
        {
            // bölüm bitince ne yapacağını yaz.
            Level_Finished();
        }

    }

    public void Level_Finished()
    {
        level_finished = true;
        buttons.SetActive(true);
        highScore += dictionary.Length * 100;
        Kalan_Kelimeler.SetActive(false);
        Parent.SetActive(false);
        menuButton.SetActive(false);
        level_TEXT.gameObject.SetActive(false);
        unit_TEXT.gameObject.SetActive(false);
        level_Text.gameObject.SetActive(false);
        unit_Text.gameObject.SetActive(false);

        if (level + 1 > max_unit_level)
        {
            PlayerPrefs.SetInt("unit", unit + 1);
            PlayerPrefs.SetInt(unit.ToString(), 1);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt((unit*10+level).ToString(), 1);
        }
        else
        {
            SaveHighScore();
        }

    }
    
    private void SaveHighScore ()
    {
        PlayerPrefs.SetInt((unit * 10 + level).ToString(), 1);
        PlayerPrefs.SetInt("level", level + 1);
        level = PlayerPrefs.GetInt("level");
    }
}