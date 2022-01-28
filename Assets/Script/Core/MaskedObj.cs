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
                //颜色和背景相同,移动到和玩家无碰撞的层级
                this.gameObject.layer = 8;
            }
        }
    }

    //根据最初的背景色初始化方块状态
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
            //设置好下一次在遮罩内，并且暂时关闭渲染
            myRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            myRenderer.enabled = false;
        }
    }
}