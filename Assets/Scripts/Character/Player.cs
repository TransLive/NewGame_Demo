using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	
    void Start()
	{
        groundCheckBox.x = GetComponent<BoxCollider2D>().bounds.size.x;
        groundCheckBox.y = GetComponent<BoxCollider2D>().bounds.size.y;
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
        if (move > 0 && !isFacingRight || move < 0 && isFacingRight && isOnGround())
            base.overturn();
        rigidBody.velocity = Mathf.Abs(move) > 0 ? new Vector2(move * maxSpeed, rigidBody.velocity.y): rigidBody.velocity;
    }
    protected override void jump()
	{
		if(Input.GetKey("space") && isOnGround()) 
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

    protected override bool isOnGround()
    {
        var RaycastHit = Physics2D.BoxCast(
        origin: transform.position,
        size: new Vector2(groundCheckBox.x - 0.1f,groundCheckBox.y),
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
}
