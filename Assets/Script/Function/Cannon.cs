using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefabBall;
    public Transform shootPointer;
    public float timeGap;
    public float force;
    public float ballDestoryTime;

    [Header("Color Setting")]
    public MaskType startColor;
    private MaskType colorType;
    

    private float timeKeeper;

    void Start()
    {
        timeKeeper = timeGap;
        colorType = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeKeeper >= 0)
        {
            timeKeeper -= Time.deltaTime;
        }
        else
        {
            Shoot();
            timeKeeper = timeGap;
        }
    }

    public void Shoot()
    {
        //生成炮弹
        GameObject bullet = Instantiate(prefabBall,shootPointer.position,Quaternion.identity);
        //初始化
        MaskedObj bulletObj = GetMaskedObj(bullet);
        bulletObj.myColor = colorType;
        bulletObj.InitColorCube();
        //射击
        Vector2 forceDir = new Vector2(shootPointer.position.x - transform.position.x, shootPointer.position.y - transform.position.y).normalized;
        bulletObj.myRg.AddForce(forceDir * force, ForceMode2D.Impulse);
        //转换颜色
        ChangeColor();
    }

    public void ChangeColor()
    {
        if(colorType == MaskType.White)
        {
            colorType = MaskType.Black;
        }
        else
        {
            colorType = MaskType.White;
        }
    }

    private MaskedObj GetMaskedObj(GameObject prefab)
    {
        MaskedObj obj = prefab.GetComponent<MaskedObj>();
        return obj;
    }

    public void Setcolor(MaskType color, MaskedObj obj)
    {
        obj.myColor = color;
    }
}
