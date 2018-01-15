using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {

    public float patrolRange;
    public Vector3 patrolDirect;
    public float chaseSpeed;
    void Start()
	{
        isFacingRight = Random.value > 0.5f;
        groundCheckBox.x = GetComponent<BoxCollider2D>().bounds.size.x;
        Debug.Log(groundCheckBox.x);
        groundCheckBox.y = GetComponent<BoxCollider2D>().bounds.size.y;
        _collider = GetComponent<BoxCollider2D>();
    }
	void Update()
	{
        
    }

    void FixedUpdate()
    {
        move();
    }

    //patrol
    private float otTime = 0.5f;//轉向間隔
    float t = 0f;
    protected override void move()
	{
        patrolDirect = isFacingRight ? Vector2.right : Vector2.left ;
        //rigidBody.AddForce(patrolDirect * speed,ForceMode2D.Force);
        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, patrolDirect * charData.speed, 0.5f);
        t += Time.deltaTime;
        if (shoudOverturn() && t > otTime)
        {
            overturn();
            t = 0;
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

    protected void chase()
    {
        if(playerInPatrolRange())
        {
        }
    }
    private bool playerInPatrolRange()
    {
        return false;
    }

    protected override void overturn()
    {
        //overturn 時機:
        //1.碰到墻 2.碰到懸崖 3.player 被發現時位於反方向 4.追著玩家打的時候
        
            isFacingRight = !isFacingRight;
            patrolDirect = -patrolDirect;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            Debug.Log("haha");
    }

    private bool shoudOverturn()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.right, groundCheckBox.x/2 + 0.01f, groundLayer);

        return hit.collider == null ? false : true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //忽略玩家碰撞体
        if(other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(_collider, other.collider, true);
        }
    }
}
