using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskChanger : StaticInstance<MaskChanger>
{
    [Header("Mask parameter")]
    private SpriteMask mask;
    public MaskType maskType;
    public float maxScale;
    public float expandTime;

    [Header("Background parameter")]
    public bool isRunCoroutine;
    public SpriteRenderer backGround_White;
    public SpriteRenderer backGround_Black;
    private SpriteRenderer maskedBackground;
    private SpriteRenderer currentBackground;

    protected override void Awake()
    {
        base.Awake();
        maskType = MaskType.Black;
    }

    void Start()
    {
        mask = GetComponent<SpriteMask>();
        maskedBackground = backGround_Black;
        currentBackground = backGround_White;
        ResetMask();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(isRunCoroutine == false)
            {
                isRunCoroutine = true;
                mask.enabled = true;
                StartCoroutine(ExpandMask(maxScale, expandTime));
            }
        }
    }

    IEnumerator ExpandMask(float scale, float time)
    {
        for (float i = 0; i <= time; i += Time.deltaTime)
        {
            float lerpscale = Mathf.Lerp(0, scale, i / time);
            transform.localScale = new Vector3(lerpscale, lerpscale, 1);
            yield return null;
        }
        ObserverManager.Instance.Noitfy();
        SwitchBackground();
        isRunCoroutine = false;
    }

    public void SwitchBackground()
    {
        maskedBackground.maskInteraction = SpriteMaskInteraction.None;
        ResetMask();
        currentBackground.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        currentBackground.sortingOrder = 2;
        maskedBackground.sortingOrder = 1;

        //change background
        SpriteRenderer temp;
        temp = currentBackground;
        currentBackground = maskedBackground;
        maskedBackground = temp;

        if(maskType == MaskType.Black)
        {
            maskType = MaskType.White;
        }
        else if(maskType == MaskType.White)
        {
            maskType = MaskType.Black;
        }
    }

    public void ResetMask()
    {
        transform.localScale = new Vector3(0,0,1);
        mask.enabled = false;
    }
}

public enum MaskType
{
    White,
    Black,
}