using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour,IMessageShow
{
    //unity component
    protected Rigidbody2D rigidBody;
    public Animator animator;
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
    public float minSpeed;
    public float speed;
    public float jumpForce;
    protected float groundCheckRadius;
    protected bool isFacingRight;
    public LayerMask groundLayer;
    
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
    }
    
	protected void overturn()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    protected bool isOnGround()
    {
        //bool onground = Physics2D.OverlapCircle(transform.position, groundCheckRadius+0.02f, groundLayer);
        var hit = Physics2D.Raycast(transform.position, -Vector2.up,groundCheckRadius+0.02f,groundLayer);
#if DEBUG
        Debug.DrawRay(transform.position, -Vector2.up, Color.green, groundCheckRadius + 0.02f);
#endif
        return hit.collider == null ? false : true;
    }
}
