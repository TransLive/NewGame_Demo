using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //unity component
    protected Rigidbody2D rigidBody;
    protected Animator animator;
    //character property
    public float attackPower;
	public float critAttack;
	public float critAttackRate;
    public float attackInterval;
    public float attakRange;
    public float damage;
    public float defense;
    public float maxHealth;
    public float currentHealth;
    public float maxSpeed;
    public float speed;

    protected bool isFacingRight;
    //character action
    protected abstract void move();
    protected abstract void jump();
    protected abstract void addAttack();
    protected abstract void addDamage();
	
	void Awake()
	{
        rigidBody = GetComponent<Rigidbody2D>();
        isFacingRight = transform.localScale.x > 0 ? true : false;
    }
    public virtual void dead()
	{
        Destroy(this);
    }

	protected void overturn()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
