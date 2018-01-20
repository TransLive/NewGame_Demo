using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    public abstract class Weapon : Item
    {
        public  ushort attackPower;
        protected BoxCollider2D attackBox;
        
        [System.Serializable]
        public struct _attactRange
        {
            public float distance;
            public float height;
        }
        public _attactRange attactRange;
        void Awake()
        {
            if (transform.parent != null)
            {
                transform.position = transform.parent.transform.position;
                transform.position = new Vector2(transform.position.x - attactRange.distance / 2, transform.position.y);
            }
            attackBox = GetComponent<Collider2D>() as BoxCollider2D;
            attackBox.size = new Vector2(attactRange.distance, attactRange.height);

        }

        
    }
}
