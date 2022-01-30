using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    public float intervalTime;
    public Transform RotatedObj;

    private bool isRotate;

    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate == false)
        {
            StartCoroutine(RotateObject(360f / intervalTime, 360f));
        }
    }

    IEnumerator RotateObject(float rate, float degrees)
    {
        isRotate = true;
        for (float i = 0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime * rate)
        {
            yield return null;
            RotatedObj.RotateAround(transform.position, Vector3.up, Time.deltaTime * rate);
        }

        isRotate = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.WinUI();
        }
    }
}
