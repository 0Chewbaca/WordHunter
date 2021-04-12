using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{

    manager manager;
    Image color;
    RectTransform scale;
    public float smaller = 0.08f;
    public bool died = false;
    bool wordsent = false;
    string word;


    void Start()
    {
        color = GetComponent<Image>();
        scale = GetComponent<RectTransform>();
        manager = GameObject.Find("game_manager").GetComponent<manager>();
        word = gameObject.name;
        color.color = Color.white;
        died = false;
    }

   
    void Update()
    {


        if (manager.pressed == false)
        {

            color.color = Color.white;
            wordsent = false;

        }

        if (died == true)
        {

            scale.localScale -= new Vector3(smaller, smaller, smaller);

            if (scale.localScale.x <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

    public void green ()
    {

        if (Input.GetMouseButtonDown(0))
            manager.pressed = true;
      
        if (manager.pressed == true)
        {
            color.color = Color.green;

            if (wordsent == false)
            {
                manager.create_pressed_buttons(word, gameObject);
                wordsent = true;
            }
        }

        
        
    }
}