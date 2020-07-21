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
        if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty); // You reset your experience, by reducing the experience by the amount to reach the next level// 
      }
      if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }
  }
  
  public int GetLevelNumber() {
    return level;
  }
  
  public float GetExperienceNormalized() {
    if (IsMaxLevel()) {
      return 1f;
    } else {
      return (float) experience / GetExperienceToNextLevel(level);
    }
  }
  
  public int GetExperience() {
    return experience;
  }
  
  public int GetExperienceToNextLevel(int level) {
    if (level < experiencePerLevel.Length) {
      return experiencePerLevel[level];
    } else {
      // Level Invalid
      Debug.LogError("Level invalid: " + level);
      return 100;
    }
  }
  
  public bool IsMaxLevel() {
    return IsMaxLevel(level);
  }
  
  public bool IsMaxLevel(int level) {
    return level == experiencePerLevel.Length - 1;
  }
  
}
  
  
