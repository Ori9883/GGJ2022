using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : StaticInstance<UIManager>,IPointerClickHandler
{
    public ButtonType button;
    public int level;

    //gameobject panel or canvas



    public void OnPointerClick(PointerEventData eventData)
    {
        if (button == ButtonType.start)
        {
            //SceneManager.LoadScene(1);
        }
        else if (button == ButtonType.back)
        {
            //SceneManager.LoadScene(0);
        }
        else if (button == ButtonType.exit)
        {
            //GameManager.Instance.EndGame();
        }
        else if (button == ButtonType.level)
        {
            switch (level)
            {
                case 1:
                    break;
                case 2:
                    break;

                //more level

            } 
        }
    }

    public void DeadUI()
    {

    }

    public void WinUI()
    {

    }
}

public enum ButtonType
{
    start,
    back,
    exit,
    level,
}
