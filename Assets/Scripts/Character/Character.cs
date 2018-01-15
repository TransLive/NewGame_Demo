using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character : MonoBehaviour,IMessageShow
{
    
    public CharacterData charData;

    #region gameplay data
    protected Rigidbody2D rigidBody;
    public Animator animator;

    protected struct GroundCheckBoxSize
    {
        public float x;
        public float y;
    }

    protected struct GroundCheckPositions
    {
        public Vector2 leftPosition;
        public Vector2 rightPositon;
    }
    protected GroundCheckBoxSize groundCheckBox;
    protected GroundCheckPositions groundCheckPositions;
    protected float groundCheckRadius;
    protected bool isFacingRight;
    public LayerMask groundLayer;
    protected Collider2D _collider;

    #endregion
    protected abstract void move();
    protected abstract void jump();
    protected abstract void addAttack();
    protected abstract void addDamage();
    protected abstract void overturn();
	void Awake()
	{
        rigidBody = GetComponent<Rigidbody2D>();
        isFacingRight = transform.localScale.x > 0 ? true : false;
    }
    public virtual void dead()
	{
    }

    //Vector2 checkPosition;
    protected virtual bool isOnGround()
    {
        groundCheckPositions.rightPositon = new Vector2(transform.position.x + groundCheckBox.x / 2, transform.position.y);
        groundCheckPositions.leftPosition = new Vector2(transform.position.x - groundCheckBox.x / 2, transform.position.y);

        var middleHit = Physics2D.Raycast(transform.position, -Vector2.up, groundCheckBox.y/2+0.1f, groundLayer);
        var leftHit = Physics2D.Raycast(groundCheckPositions.leftPosition, -Vector2.up, groundCheckBox.y/2+0.1f, groundLayer);
        var rightHit = Physics2D.Raycast(groundCheckPositions.rightPositon, -Vector2.up, groundCheckBox.y/2+0.1f, groundLayer);

        //Debug.DrawRay(groundCheckPositions.leftPosition, -Vector2.up * (groundCheckBox.y+0.02f), Color.green, 0.1f);

        return middleHit.collider == null && leftHit.collider == null && rightHit.collider == null ? false : true;
    }
}
