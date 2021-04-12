using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_hider : MonoBehaviour
{
    public GameObject Hidden_Things;
    public GameObject Not_Hidden;

   public void Menu_Hider()
    {
        if (!Hidden_Things.active)
        {
            Hidden_Things.SetActive(true);
            Not_Hidden.SetActive(false);
        }
        else
        {
            Hidden_Things.SetActive(false);
            Not_Hidden.SetActive(true);
        }
    }
}
