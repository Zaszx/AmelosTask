using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager 
{
    public Text healthText;
	public UIManager () 
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
	}
	
	public void Tick () 
    {
        healthText.text = "Health: " + Globals.player.GetRemainingHealth();
	}
}
