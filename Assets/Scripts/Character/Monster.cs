using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {

    public float patrolRadius;
    public Vector2 patrolDirect;
    private Vector2 patrolStartPoint;
    public float chaseSpeed;
    public GameObject objDetector;

    void detectorInit()
    {
        objDetector.transform.parent = this.transform;
    }

    //    private Detector detector;
    void Start()
	{
        base.Start();
        patrolStartPoint = transform.position;
        isFacingRight = Random.value > 0.5f ? true : false;
        if (!isFacingRight) overturn();

        mainCheckBox.x = base.mainCollider.bounds.size.x;
        mainCheckBox.y = base.mainCollider.bounds.size.y;
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
            //Debug.Log("haha");
            t = 0;
            overturn();
        }
    }
	protected override void jump()
	{

	}
    protected override void addAttack()
	{

	}

    protected virtual void chase()
    {
        if(isPlayerInPatrolRange())
        {
        }
    }
    private bool isPlayerInPatrolRange()
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
    }

    private bool shoudOverturn()
    {
        return (!isInPatrolRange() || isCollideToGround()) ? true : false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //忽略玩家碰撞体
        if(other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(mainCollider, other.collider, true);
        }
    }

    private bool isInPatrolRange()
    {
        if (Mathf.Abs(transform.position.x - patrolStartPoint.x) >= patrolRadius)
            return false;
        else return true;
    }

    private bool isCollideToGround()
    {
        var hitRight = Physics2D.Raycast(transform.position, Vector2.right, mainCheckBox.x/2 + 0.01f, groundLayer);
        var hitLeft = Physics2D.Raycast(transform.position, Vector2.left, mainCheckBox.x/2 + 0.01f, groundLayer);
        
        return (hitRight.collider == null && hitLeft.collider == null) ? false : true;
    }

    public override void RelayOnTriggerEnter(Collider2D other)
    {
    }
}
