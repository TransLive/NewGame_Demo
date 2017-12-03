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
    public float maxEnergy;
    public float currentEnergy;
    public float maxSpeed;
    public float minSpeed;
    public float speed;
    public float jumpForce;
    protected struct GroundCheckBoxSize
    {
        public float x;
        public float y;
    }
    protected GroundCheckBoxSize groundCheckBox;
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
    protected virtual bool isOnGround()
    {
        //bool onground = Physics2D.OverlapBox(transform.position, new Vector2(groundCheckBox.x /10, groundCheckBox.y), 0f, groundLayer);
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, groundCheckBox.x+0.02f, groundLayer);
        //var hitter = Physics2D.BoxCast(transform.position,new Vector2(groundCheckBox.x,groundCheckBox.y),)
#if DEBUG
        Debug.DrawRay(transform.position, -Vector2.up * (groundCheckBox.x+0.02f), Color.green, 0.1f);
#endif
        return hit.collider == null ? false : true; //onground;
    }
}
