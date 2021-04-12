using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingActives : MonoBehaviour
{
    public GameObject Levelbuttons;
    public GameObject Menubuttons;

    void Start() 
    {
        if (Parameters.is_menu == true)
        {
            Levelbuttons.SetActive(true);
            Menubuttons.SetActive(false);
        }
        
    }


}
