using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWeapon :Items.Weapon {

	// Use this for initialization
	void Start () {
		id = 30000;
        _name = "hand";
        attackPower = 10;
        attactRange.distance = 4;
        attactRange.height = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
