using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
  // This class is used for testing the game //
  
  [SerializeField] private LevelWindow levelWindow;
  [SerializeField] private Player player;
  [SerializeField] private EquipWindow equipWindow;
  
  private void Awake() {
    LevelSystem levelSystem = new LevelSystem();
    levelWindow.SetLevelSystem(levelSystem);
    equipWindow.SetLevelSystem(levelSystem);
    
    LevelSystemAnimated levelSystemAnimated = new LevelSystemAnimted(levelSystem);
    levelWindow.SetLevelSystemAnimated(levelSystemAnimated);
    player.SetLevelSystemAnimated(levelSystemAnimated);
  }
}

