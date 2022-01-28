using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedBulletObj : MaskedObj
{
    public float timeToDestory;
    public float maxScale;

    private float timeKeeper;
    private float totalTime;
    public override void OnStart()
    {
        base.OnStart();
        totalTime = timeToDestory;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(timeToDestory >= 0)
        {
            timeToDestory -= Time.deltaTime;
        }
        else
        {
            RemoveOB();
            Destroy(this.gameObject);
        }

        if (myRg.velocity.magnitude >= 0.1)
        {
            timeKeeper += Time.deltaTime;
            float lerpScale = Mathf.Lerp(1, maxScale, timeKeeper / totalTime);
            transform.localScale = new Vector3(lerpScale, lerpScale, 1);
        }

    }

    public void RemoveOB()
    {
        ObserverManager.Instance.RemoveObserver(this);
    }
}
