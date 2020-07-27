using System.Collections; // As always, initialize what part of Unity you're using for the game //
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EquipWindow : MonoBehaviour { // The point of this class is to establish the script of equipping anything during the game //
  
  [SerializeField] private Player player; // The player must be equipped for the game //
  [SerializeField] private Sprite headSprite; // The headSprite sprite must be equipped for the game //
  [SerializeField] private Sprite helmet1Sprite; // The helmet1Sprite sprite must be equipped for the game //
  [SerializeField] private Sprite helmet2Sprite; // The helmet2Sprite sprite must be equipped for the game //
  
  private LevelSystem levelSystem; // In relation to equipping items, the LevelSystem must work along with EquipWindow when choosing new available items after leveling up //
  
  private void Awake() { // Again, this Awake variable is meant to activate the equipping and leveling system actions of the game //
  	transform.Find("equipNoneBtn").GetComponent<Button_UI>().ClickFunc = () => player.SetEquip(Player.Equip.None); // You need to set up the equipping mechanism when there is no item to equip //
	transform.Find("equipHelmet1Btn").GetComponent<Button_UI>().ClickFunc = () => { // You need to set up the equipping mechanism when there is Helmet1 to be equipped during the game, at which the ClickFunc will be used to trigger equipping the item //
		if (levelSystem.GetLevelNumber() >= 4) { // If you reach the levelSystem number 4, you are eligible to equip the Helmet1 asset //
				player.SetEquip(Player.Equip.Helmet_1); // You as the player are eligible to set this item //
		} else { // If you haven't reached this level, then //
			Tooltip_Warning.ShowTooltip_Static("Level Required 5!"); // If you aren't suited to click the item you want to equip, a toolmenu will notify you stating 'Level Required 5!' //
		}
	};
	transform.Find("equipHelmet2Btn").GetComponent<Button_UI>().ClickFunc = () => { // You are telling the game to find Helmet2 within the game, at which you are connecting it to the mechanism that makes the item clickable enough for you to equip it, through ClickFun and GetButton //
		if (levelSystem.GetLevelNumber() >= 9) { // If you reach Level 10 //
			player.SetEquip(Player.Equip.Helmet_2); // You as the player, are eligible to equip Helmet2 //
		} else { // Otherwise //
			Tooltip_Warning.ShowTooltip_Static("Level Required 10!"); // You order the game to give Tooltip_Warning stating 'Level Required 10!' to be eligible to equip the item in case you haven't reached level 10 //
		}
	};
	
	Tooltip_ItemStats.AddTooltip(transform.Find("equipNoneBtn"), headSprite, "None", "Just your head, not much protectin", 1); // You are setting the variable Tooltip_ItemStates to AddToolTop to communicate that the headSprite isn't very effective //
	Tooltip_ItemStats.AddTooltip(transform.Find("equipHelmet1Btn"), helmet1Sprite, "Basic Helmet", "Simple protetion, better than nothing", 5); // For the next item, which is helmet1Sprite, you are stating that it's a basic helmet using Tooltip_ItemStats.AddTooltip //
	Tooltip_ItemStats.AddTooltip(transform.Find("equipHelmet2Btn"), helmet2Sprite, "Epic Helmet", "Epic protection, looks great too!", 10); // You are revealing for helmet2Sprite that it's an 'Epic Helmet' with 'Epic protection, looks great too!' //
}

	public void SetLevelSystem(LevelSystem levelSystem) { // You are concluding the line of code by setting the LevelSystem with all of the EquipWindow variables intact //
		this.levelSystem = levelSystem;
	}
}
	
		
		
	
	
    
    
