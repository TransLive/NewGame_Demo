using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Detector:MonoBehaviour
{
    Monster monster;
    void Start()
    {
        GameObject objMonster = gameObject.transform.parent.gameObject;
        monster = objMonster.GetComponent<Monster>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        monster.RelayOnTriggerEnter(other);
    }
}
