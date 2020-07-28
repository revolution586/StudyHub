using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You must begin every piece of code by establishing what you're using //
// This file is meant to handle all of the base logic of the game //

public class LevelSystem {
  
  // Because this class doesn't have complex variables, there's no need to add Mono Behaviour //
  
  public event EventHandler OnExperienceChanged;
  public event EventHandler OnLevelChanged;
  
  private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 160, 180, 200, 220, 250, 300, 400 };
  
  private int level;
  private int experience;
  
  // Above, you set the integers for the level and the experience in the game //
  
  public LevelSystem() {
    level = 0;
    experience = 0;
    // In this code, you must set the integers to a number //
  }
  
  public void AddExperience(int amount) {     // "int amount" is the parameter you'll be receiving for the amount of experience added //
    if (!IsMaxLevel()) {
      experience += amount; // Here, you increase the experience by the amount using += //
      while (!IsMaxLevel() && experience >= GetExperienceToNextLevel(level)) { //This code is meant to establish what happens when you have enough experience to level up //
        experience -= GetExperienceToNextLevel(level);
        level++; // Increase the level //
        if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty); // You reset your experience, by reducing the experience by the amount to reach the next level // 
      }
      if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty); // You are restating the same line of code to make the system understand your intentions //
    }
  }
  
  public int GetLevelNumber() { // You are asking the public integer GetLevelNumber to return a level number (e.g. Level 10) in correlation to the required XP that's been obtained //
    return level; // The level is being returned as the new number after the XP was gained //
  }
  
  public float GetExperienceNormalized() { // This float variable is meant to normalize the experience system to return a new level in order to get to the next level //
    if (IsMaxLevel()) { // Don't forget, a float variable is contains numbers to needed to activate a function //
      return 1f;
    } else {
      return (float) experience / GetExperienceToNextLevel(level); // Return the designated float of numbers in order to GetExperienceToNextLevel(level) //
    }
  }
  
  public int GetExperience() { // You are establishing the public integer GetExperience to return experience once that experience has been gained through playing //
    return experience;
  }
  
  public int GetExperienceToNextLevel(int level) {
    if (level < experiencePerLevel.Length) { // To get to the next level through required experience, if your current level in the game is less than the required number of experience needed to enter the next level //
      return experiencePerLevel[level]; // Return the required experiencePerLevel variable in response, meaning that the level won't change if you don't get enough XP //
    } else { // Otherwise //
      // Level Invalid
      Debug.LogError("Level invalid: " + level); // You are at the wrong level and an error has occurred //
      return 100; // Return the 100 XP that couldn't be registered due to the Debug.LogError //
    }
  }
  
  public bool IsMaxLevel() { // For this boolean variable, when you're at the maximum level, you're telling the system to stay at that level through return IsMaxLevel //
    return IsMaxLevel(level);
  }
  
  public bool IsMaxLevel(int level) {
    return level == experiencePerLevel.Length - 1; // When you assign IsMaxLevel to int level, you are telling the system to stop increasing the level if the experiencePerLevel.Length is getting reduced (-1) by one integer //
  }
  
}
  
  
