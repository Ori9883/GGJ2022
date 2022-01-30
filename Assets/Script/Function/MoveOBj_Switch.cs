using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOBj_Switch : MonoBehaviour
{
    public float maxMovedistance;
    public float moveTime;
    public GameObject movableObj;

    public bool moving = false;

    private float currentTime = 0;

    private void Update()
    {
        if (currentTime < 0)
        {
            currentTime = 0;
        }
        else if(currentTime > moveTime)
        {
            currentTime = moveTime;
        }
    }

    public IEnumerator Move()
    {
        for (;currentTime < moveTime; currentTime += Time.deltaTime)
        {
            movableObj.transform.localPosition = new Vector3(0, Mathf.Lerp(0, maxMovedistance, currentTime / moveTime), 0);
            yield return null;
        }

        moving = false;
    }

    public IEnumerator Reset()
    {
        for (; currentTime > 0.01f; currentTime -= Time.deltaTime)
        {
            movableObj.transform.localPosition = new Vector3(0, Mathf.Lerp(maxMovedistance, 0, (moveTime - currentTime )/ moveTime), 0);
            yield return null;
        }

        moving = false;
    }
}
