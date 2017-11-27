using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	
    void Start()
	{
        groundCheckBox.x = GetComponent<CapsuleCollider2D>().bounds.size.x;
        groundCheckBox.y = GetComponent<CapsuleCollider2D>().bounds.size.y;
    }
	void Update()
	{
		this.jump();
        addAttack();
        animator.SetBool("isJump", isOnGround() ? false : true);
        animator.SetBool("isOnGround", isOnGround());
    }
	void FixedUpdate()
	{
        this.move();
		animator.SetFloat("playerSpeed", Mathf.Abs(rigidBody.velocity.x));
    }
    protected override void move()
	{
		float move = Input.GetAxisRaw("Horizontal");
        if (rigidBody.velocity.y <= 0 && Mathf.Abs(move) > 0)
        {
            //this.PRINT(rigidBody.velocity.ToString());
            rigidBody.velocity = new Vector2(move/Mathf.Abs(move) + move * maxSpeed, rigidBody.velocity.y);

            //速度方向為正且朝左的情況下或反之，翻轉sprite
            if (move > 0 && !isFacingRight || move < 0 && isFacingRight)
                base.overturn();
		}
    }
    protected override void jump()
	{
		if(Input.GetKey("space") && rigidBody.velocity.y <= 0 && isOnGround())
		{
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
	}
    protected override void addAttack()
	{
		if(Input.GetKey("v"))
			animator.SetTrigger("attacking");
    }
    protected override void addDamage()
	{

	}
}
