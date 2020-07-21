using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
  // This class is used for testing the game //
  
  [SerializeField] private LevelWindow levelWindow; // You are setting the private integer for the levelWindow //
  [SerializeField] private Player player; // You are setting the private integer for the Player //
  [SerializeField] private EquipWindow equipWindow; // You are setting the private integer to equip the window //
  
  // [SerializeField] Serialization is the automatic process of transforming data structures or object states into a format that Unity can store and reconstruct later. //
  // Some of Unity’s built-in features use serialization; features such as saving and loading, the Inspector, window, instantiation and Prefabs //

  private void Awake() { // Awake is called when the script instance is being loaded. //
    LevelSystem levelSystem = new LevelSystem(); // Awake is called either when an active GameObject that contains the script is initialized when a Scene loads, //
    // or when a previously inactive GameObject is set to active, or after a GameObject created with Object.Instantiate is initialized. //
     // Use Awake to initialize variables or states before the application starts. // 
    levelWindow.SetLevelSystem(levelSystem); // You are using levelWindow to set the levelSystem //
    equipWindow.SetLevelSystem(levelSystem); // You are using equipWindow to set the levelSystem //
    
    LevelSystemAnimated levelSystemAnimated = new LevelSystemAnimated(levelSystem); // In all code, repeating the same variable twice establishes what you're trying to do //
    // That's why it's always necessary to do LevelSystemAnimted levelSystemAnimated //
    levelWindow.SetLevelSystemAnimated(levelSystemAnimated); // In this code, you are using the levelWindow to set the animated level system //
    player.SetLevelSystemAnimated(levelSystemAnimated); // In this code, you are using the player to trigger the animated level system, as the player is an integer connected to the level system //
  }
}

