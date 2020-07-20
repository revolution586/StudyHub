using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EquipWindow : MonoBehaviour {
  
  [SerializeField] private Player player;
  [SerializeField] private Sprite headSprite;
  [SerializeField] private Sprite helmet1Sprite;
  [SerializeField] private Sprite helmet2Sprite;
  
  private LevelSystem levelSystem;
  
  private void Awake() {
  	transform.Find("equipNoneBtn").GetComponent<Button_UI>().ClickFunc = () => player.SetEquip(Player.Equip.None);
	transform.Find("equipHelmet1Btn").GetComponent<Button_UI>().ClickFunc = () => {
		if (levelSystem.GetLevelNumber() >= 4) {
				player.SetEquip(Player.Equip.Helmet_1);
		} else {
			Tooltip_Warning.ShowTooltip_Static("Level Required 5!");
		}
	};
	transform.Find("equipHelmet2Btn").GetComponent<Button_UI>().ClickFunc = () => {
		if (levelSystem.GetLevelNumber() >= 9) {
			player.SetEquip(Player.Equip.Helmet_2);
		} else {
			Tooltip_Warning.ShowTooltip_Static("Level Required 10!");
		}
	};
	
	Tooltip_ItemStats.AddTooltip(transform.Find("equipNoneBtn"), headSprite, "None", "Just your head, not much protectin", 1);
	Tooltip_ItemStats.AddTooltip(transform.Find("equipHelmet1Btn"), helmet1Sprite, "Basic Helmet", "Simple protetion, better than nothing", 5);
	Tooltip_ItemStats.AddTooltip(transform.Find("equipHelmet2Btn"), helmet2Sprite, "Epic Helmet", "Epic protection, looks great too!", 10);
}

	public void SetLevelSystem(LevelSystem levelSystem) {
		this.levelSystem = levelSystem;
	}
}
	
		
		
	
	
    
    
