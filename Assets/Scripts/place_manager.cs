using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class place_manager : MonoBehaviour
{
    int screen_width = Screen.width;
    int screen_height = Screen.height;
    int Redmi_7_height = 2340;
    int Redmi_7_width = 1080;
    float width_To_Be;
    float height_To_Be;
    public GameObject objects;
    public Text text;


    void Start()
    {
        width_To_Be = (float) screen_width / Redmi_7_width;
        height_To_Be = (float)screen_height / Redmi_7_height;

        objects.transform.position = new Vector2(576f * width_To_Be, 1485.84f * height_To_Be);
        text.transform.position = new Vector2(1050f * width_To_Be, 1495.84f * height_To_Be);

    }

    
    void Update()
    {
        
    }
}
