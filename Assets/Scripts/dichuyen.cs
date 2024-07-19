using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{ 
    public float trai_phai;
    public float tocdo;

    public float docao;
    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    public Transform _duocPhepNhay;
    public LayerMask san;
    private bool duocPhepNhay;
    private bool isfacingRight = true;
    private bool isGround = true;
    private Rigidbody2D rb;
    private Animator anim;
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        duocPhepNhay = Physics2D.OverlapCircle(_duocPhepNhay.position, 0.2f,san);
        // di chuyển
        trai_phai = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(trai_phai * tocdo, rb.velocity.y);
        
        // flip
        flip();
        // jump

        if (Input.GetKeyDown(KeyCode.W) && duocPhepNhay && isGround)
        {
                rb.velocity = new Vector2(rb.velocity.x, docao);
                isGround = false;
                anim.SetBool("isJumping", !isGround);

        }
        // anim
        anim.SetFloat("move", Mathf.Abs(trai_phai));
        anim.SetFloat("yvelocity", rb.velocity.y);
        
        // dash
        if(Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false)
        {
            tocdo += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
        }
        if(_dashTime <= 0 && isDashing == true)
        {
            tocdo -= dashBoost;
            isDashing = false;
        } else 
        {
            _dashTime -= Time.deltaTime;
        }
    }
    

    void flip()
    {
        if (isfacingRight && trai_phai < 0 || !isfacingRight && trai_phai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
        }
    }
  public void OnTriggerEnter2D(Collider2D collision){
        isGround = true;
        anim.SetBool("isJumping", !isGround);

    }

}
