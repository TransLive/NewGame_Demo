using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
    public Slider redHealthBar;
	public Slider yellowHealthBar;
    public float deYellowBarSpeed = 0.9f;
    
    
    public GameManager gameManager;
    void Start()
	{
        
        redHealthBar.maxValue = gameManager.player.maxHealth;
		yellowHealthBar.maxValue = redHealthBar.maxValue;
    }

	void Update()
	{
        redHealthBar.value = gameManager.player.currentHealth;
		yellowHealthBar.value = redHealthBar.value < yellowHealthBar.value ? 
		Mathf.Lerp(yellowHealthBar.value, redHealthBar.value, deYellowBarSpeed) : redHealthBar.value;
    }

}
