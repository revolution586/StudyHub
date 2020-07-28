using System.Collections; // Write down all necessary components used for UnityEngine //
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelWindow: MonoBehaviour { // The public class LevelWindow is meant to handle the GUI aspect of the leveling system //
  
  private Text levelText; // You are creating the 'Text' aspect of the game //
  private Image experienceBarImage; // You creating the experienceBarImage aspect of the game //
  private LevelSystem levelSystem; // You are inputting the LevelSystem to connect it to other GUI aspects of the game //
  private LevelSystemAnimated levelSystemAnimated; // You are inputting the LevelSystemAnimated aspect to connect it to other GUI aspects of the game //
  
  private void Awake() {
    levelText = transform.Find("levelText").GetComponent<Text>();
    experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();
    
    transform.Find("experience5Btn").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(5);
    transform.Find("experience50Btn").GetCompinent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(50);
    transform.Find("experience500Btn").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(500);
  }
  
  private void SetExperienceBarSize(float experienceNormalized) {
    experienceBarImage.fillAmount = experienceNormalized;
  }
  
  private void SetLevelNumber(int levelNumber) { // You are setting the level number of the game in response to the changing integer levelNumber //
    levelText.text = "LEVEL\n" + (levelNumber + 1); // If the levelText.text has a point of 'levelNumber + 1' added to it, then state the level and it's number in the experienceBarImage using "LEVEL\n" //
  }
  
  public void SetLevelSystem(LevelSystem levelSystem) { // You are setting the levelSystem //
    this.levelSystem = levelSystem;
  }
  
  public void SetLevelSystemAnimated(LevelSystemAnimted levelSystemAnimated)
    // Set the LevelSystemAnimated object
    this.levelSystemAnimated = levelSystemAnimated;
  
    // Update the starting values
  SetLevelNumber(levelSystemAnimated.GetLevelNumber());
  SetExperienceBarSize(levelSystemAnimated.GetExperienceNormalized());
  
  // Subscribe to the changed events
  levelSystemAnimated.OnExperienceChanged += LevelSystemAnimated_OnExperienceChanged;
  levelSystemAnimated.OnLevelChanged += LevelSystemAnimated_OnLevelChanged;
}

  private void LevelSystemAnimated_OnLevelChanged(object sender, System.EventArgs e) {
  // Level changed, update text
  SetLevelNumber(levelSystemAnimated.GetLevelNumber());
}

  private void LevelSystemAnimated_OnExperienceChanged(object sender, System.EventArgs e) {
  // Experience changed, update bar size
  SetExperienceBarSize(levelSystemAnimated.GetExperienceNormalized());
  }
}
