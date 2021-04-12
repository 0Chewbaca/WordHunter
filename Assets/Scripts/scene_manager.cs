using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class scene_manager : MonoBehaviour
{
    public void LoadScreen(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Reset_Levels()
    {
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("unit", 1);

    }

    public void setLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
    }

    public void setUnit(int unit)
    {
        PlayerPrefs.SetInt("unit", unit);
    }

    public void level_Managing()
    {
        string word = gameObject.name;

        if (PlayerPrefs.HasKey(word))
        {

            //if (PlayerPrefs.GetInt(word) == 1)
            //{
            //    SceneManager.LoadScene(1);
            //}
            //else
            //{
            //    SceneManager.LoadScene(3);
            //}

            SceneManager.LoadScene(3);

        } 

    }
}