using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    public abstract class Weapon : Item
    {
        public  ushort attackPower;
        public BoxCollider2D attackBox;
        public Character character;

        [System.Serializable]
        public struct _attactRange
        {
            public float distance;
            public float height;
        }
        public _attactRange attactRange;
        public void Start()
        {
            if (transform.parent != null)
            {
                //TODO:如何讓attackBox 按照玩家的朝向放置
                transform.position = transform.parent.transform.position;
                character = transform.parent.gameObject.GetComponent<Character>();

                if (!character.isFacingRight)
                {
                    transform.position = new Vector2(transform.position.x + attactRange.distance / 2, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - attactRange.distance / 2, transform.position.y);
                }
            }
            attackBox = GetComponent<Collider2D>() as BoxCollider2D;
            attackBox.size = new Vector2(attactRange.distance, attactRange.height);
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            character.RelayOnTriggerEnter(other);
            attackBox.enabled = false;
        }
    }
}
