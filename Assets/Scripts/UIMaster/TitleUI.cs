using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject player;

    void OnEnable()
    {
        Invoke("HideTitle", 2f);
    }

    public void ShowTitle()
    {
        title.SetActive(true);
    }

    void HideTitle()
    {
        title.SetActive(false);
        player.SetActive(true);
    }

    
}
