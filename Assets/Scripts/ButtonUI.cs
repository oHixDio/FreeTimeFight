using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] GameObject mainPlayer;
    Actor actor;
    private void Awake()
    {
        actor = mainPlayer.GetComponent<Actor>();
    }

    public void OpenInventory()
    {
        Debug.Log("OpenInventory!!!!");
    }

    public void MinusButton()
    {
        Debug.Log("Minus");
    }

    public void PlusButton()
    {
        Debug.Log("Plus");
    }

    public void SystemButton()
    {
        Debug.Log("System!!");
    }

    public void RightPanelDown()
    {
        actor.IsRight = true;
    }
    public void RightPanelUp()
    {
        actor.IsRight = false;
    }

    public void LeftPanelDown()
    {
        actor.IsLeft = true;
    }
    public void LeftPanelUp()
    {
        actor.IsLeft = false;
    }
}
