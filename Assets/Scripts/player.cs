using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	void Start()
	{
	}
	void FixedUpdate()
	{
        move();
    }
    protected override void move()
	{
		float move = Input.GetAxis("Horizontal");
		rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

		//速度方向為正且未朝右的情況下，翻轉sprite
		if (move > 0 && !isFacingRight)
		{
			base.overturn();
		}
		//反之
		else if (move < 0 && isFacingRight)
		{
			base.overturn();
		}
	}
    protected override void jump()
	{

	}
    protected override void addAttack()
	{

	}
    protected override void addDamage()
	{

	}
}
