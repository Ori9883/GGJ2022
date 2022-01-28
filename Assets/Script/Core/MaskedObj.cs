using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedObj : MonoBehaviour,Observer
{
    public MaskType myColor;

    SpriteRenderer myRenderer;
    public Rigidbody2D myRg;
    public Collider2D myColl;
//    public Collider2D myTrigger;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        RegisterOB();
        myRg = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        Init();
        InitColorCube();
    }

    public void Init()
    {
        if(myColor == MaskType.White)
        {
            myRenderer.color = Color.white;
        }
        else if(myColor == MaskType.Black)
        {
            myRenderer.color = Color.black;
        }
    }

    public void RegisterOB()
    {
        ObserverManager.Instance.Addobserver(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mask"))
        {
            if (myColor != MaskChanger.Instance.maskType)
            {
                this.gameObject.layer = 9;
                myRenderer.enabled = true;
                myRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
            else
            {
                //��ɫ�ͱ�����ͬ,�ƶ������������ײ�Ĳ㼶
                this.gameObject.layer = 8;
            }
        }
    }

    //��������ı���ɫ��ʼ������״̬
    public void InitColorCube()
    {
        if(myColor == MaskChanger.Instance.maskType)
        {
            this.gameObject.layer = 9;
            myRenderer.enabled = true;
            myRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
        else
        {
            this.gameObject.layer = 8;
            myRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            myRenderer.enabled = false;
        }
    }

    public void NotifyChange()
    {
        if(myColor != MaskChanger.Instance.maskType)
        {
            myRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
        else
        {
            //���ú���һ���������ڣ�������ʱ�ر���Ⱦ
            myRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            myRenderer.enabled = false;
        }
    }
}