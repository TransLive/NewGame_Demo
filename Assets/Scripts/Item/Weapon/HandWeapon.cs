using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWeapon :Items.Weapon {

	// Use this for initialization
	void Start () {
        base.Start();
        id = 30000;
        _name = "hand";
        attackPower = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
