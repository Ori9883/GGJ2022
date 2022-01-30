using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rg;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rg.velocity.x));
        anim.SetBool("jump",player.isJump);
        anim.SetBool("ground", player.isGround);
    }
}
