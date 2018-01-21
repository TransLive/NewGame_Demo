using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character : MonoBehaviour,IMessageShow
{
    
    public CharacterData charData;
    protected Items.Weapon holdingWeapon;

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
    protected GroundCheckBoxSize mainCheckBox;
    
    protected GroundCheckPositions groundCheckPositions;
    protected float groundCheckRadius;
    public bool isFacingRight;
    public LayerMask groundLayer;
    private Collider2D _mainCollider;
    protected Collider2D mainCollider{
        get { 
            if(_mainCollider == null)
                _mainCollider = GetComponent<BoxCollider2D>();
            return _mainCollider; }
        set { _mainCollider = value;}
    }
    #endregion
    protected abstract void move();
    protected abstract void jump();
    protected abstract void addAttack();
    public virtual void addDamage(int damge)
    {
        charData.currentHealth -= damge;
    }
    protected abstract void overturn();
    public void Start()
	{
        rigidBody = GetComponent<Rigidbody2D>();
        groundLayer = 1<<LayerMask.NameToLayer("Ground");
        isFacingRight = transform.localScale.x > 0 ? true : false;
        
        Debug.Log(isFacingRight);
    }
    protected virtual void dead()
    {

    }

    //Vector2 checkPosition;
    protected virtual bool isOnGround()
    {
        groundCheckPositions.rightPositon = new Vector2(transform.position.x + mainCheckBox.x / 2, transform.position.y);
        groundCheckPositions.leftPosition = new Vector2(transform.position.x - mainCheckBox.x / 2, transform.position.y);

        var middleHit = Physics2D.Raycast(transform.position, -Vector2.up, mainCheckBox.y/2+0.1f, groundLayer);
        var leftHit = Physics2D.Raycast(groundCheckPositions.leftPosition, -Vector2.up, mainCheckBox.y/2+0.1f, groundLayer);
        var rightHit = Physics2D.Raycast(groundCheckPositions.rightPositon, -Vector2.up, mainCheckBox.y/2+0.1f, groundLayer);

        //Debug.DrawRay(groundCheckPositions.leftPosition, -Vector2.up * (groundCheckBox.y+0.02f), Color.green, 0.1f);

        return middleHit.collider == null && leftHit.collider == null && rightHit.collider == null ? false : true;
    }

    public abstract void RelayOnTriggerEnter(Collider2D other);

}
