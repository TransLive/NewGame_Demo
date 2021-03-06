﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Character {
    
    struct totalAttack
    {
        
    }

    void Start()
	{
        base.Start();
        mainCheckBox.x = base.mainCollider.bounds.size.x;
        mainCheckBox.y = base.mainCollider.bounds.size.y;
        holdingWeapon = GetComponentInChildren<Items.Weapon>();
    }
	void Update()
	{
        addAttack();
        setAnimator();
        
    }
	void FixedUpdate()
	{
        jump();
        move();
    }
    protected override void move()
	{
		float move = Input.GetAxis("Horizontal");
        if (base.isOnGround())
        {
            if (move > 0 && !isFacingRight || move < 0 && isFacingRight)
            {
                overturn();
            }
            rigidBody.velocity = Mathf.Abs(move) > 0 ? new Vector2(move * charData.maxSpeed, rigidBody.velocity.y): rigidBody.velocity;
        }
    }
    protected override void jump()
	{
		if(Input.GetKey("space") && isOnGround()) 
		{
            rigidBody.AddForce(new Vector2(0, charData.jumpForce), ForceMode2D.Impulse);
        }
	}
    float t = 0;
    protected override void addAttack()
	{
        if (Input.GetKeyDown("v") && (Time.time - t) >= charData.attackCd)
        {
            t = Time.time;
            animator.SetTrigger("attacking");
            Debug.Log("haha");
            holdingWeapon.attackBox.enabled = true;
        }
    }

    protected override void dead()
    {

    }

    //射線盒檢測
    protected override bool isOnGround()
    {
        var RaycastHit = Physics2D.BoxCast(
        origin: transform.position,
        size: new Vector2(mainCheckBox.x - 0.1f,mainCheckBox.y),
        angle: 0f,
        direction: Vector2.down,
        distance: 0.01f,
        layerMask: this.groundLayer
        );
        return RaycastHit;
    }

    void setAnimator()
    {
        animator.SetBool("isJump", isOnGround() ? false : true);
        animator.SetBool("isOnGround", isOnGround());
        animator.SetFloat("playerSpeed", Mathf.Abs(rigidBody.velocity.x));
    }

    protected override void overturn()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public override void RelayOnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            (other.transform.gameObject.GetComponent<Character>() as Monster).addDamage(charData.attackPower + holdingWeapon.attackPower);
        }
    }
}