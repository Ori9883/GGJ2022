using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public MoveOBj_Switch moveableObj;
    public GameObject button;
    public GameObject checkBox;
    public LayerMask checkLayer;

    public float timeTobottom;
    private float currentTime = 0;
    void Update()
    {
        Collider2D coll = Physics2D.OverlapBox(new Vector2(checkBox.transform.position.x, checkBox.transform.position.y), checkBox.GetComponent<BoxCollider2D>().size,0f,checkLayer);
        Debug.Log(coll);
        if(coll != null)
        {
            button.transform.localPosition = new Vector3(0, Mathf.Lerp(0,-0.5f,currentTime/timeTobottom),0);
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime -= Time.deltaTime;
            button.transform.localPosition = new Vector3(0, Mathf.Lerp(-0.5f, 0,(timeTobottom - currentTime )/ timeTobottom), 0);
        }

        if(button.transform.localPosition.y < -0.45f)
        {
            if(moveableObj.moving == false)
            {
                moveableObj.moving = true;
                StartCoroutine(moveableObj.Move());
            }
        }
        else if(button.transform.localPosition.y > -0.1f)
        {
            if (moveableObj.moving == false)
            {
                moveableObj.moving = true;
                StartCoroutine(moveableObj.Reset());
            }
        }

        if(currentTime > timeTobottom)
        {
            currentTime = timeTobottom;
        }
        else if(currentTime < 0)
        {
            currentTime = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(checkBox.transform.position, new Vector3(2,1,0));
        Gizmos.color = Color.blue;
    }
}
