using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenus : MonoBehaviour
{
    public GameObject[] profileMenus;

    public void DisableMenu(int index) 
    {
        for (int i = 0; i < profileMenus.Length; i++) 
        {
            profileMenus[i].SetActive(false);
        }
        profileMenus[index].SetActive(true);
    }
}
