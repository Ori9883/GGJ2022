using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : StaticInstance<UIManager>,IPointerClickHandler
{
    public ButtonType button;
    public int level;

    public GameObject creditPanel;
    public GameObject deadPanel;
    public GameObject winPanel;
    //gameobject panel or canvas



    public void OnPointerClick(PointerEventData eventData)
    {
        if (button == ButtonType.start)  //����ѡ��
        {
            SceneManager.LoadScene(1);
        }
        else if(button == ButtonType.credit)  //��������Ϣ
        {
            SceneManager.LoadScene(7);
        }
        else if (button == ButtonType.back)  //����������
        {
            if(level == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        else if (button == ButtonType.exit)  //�˳���Ϸ
        {
            Application.Quit();
        }
        else if (button == ButtonType.level)  //ѡ��ؿ�
        {
            switch (level)
            {
                case 0:
                    break;
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    SceneManager.LoadScene(3);
                    break;
                case 3:
                    SceneManager.LoadScene(4);
                    break;
                case 4:
                    SceneManager.LoadScene(5);
                    break;
                case 5:
                    SceneManager.LoadScene(6);
                    break;
                case 6:
                    SceneManager.LoadScene(7);
                    break;
                case 7:
                    SceneManager.LoadScene(8);
                    break;
                case 8:
                    SceneManager.LoadScene(9);
                    break;
                case 9:
                    SceneManager.LoadScene(10);
                    break;

                    //more level

            } 
        }
        else if(button == ButtonType.nextlevel)  //������һ��
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
        else if(button == ButtonType.retry) //���Ա���
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
    }

    public void DeadUI()
    {
        deadPanel.SetActive(true);
    }

    public void WinUI()
    {
        winPanel.SetActive(true);
    }
}

public enum ButtonType
{
    start,
    credit,
    exit,
    back,
    level,
    nextlevel,
    retry,
    none,
}
