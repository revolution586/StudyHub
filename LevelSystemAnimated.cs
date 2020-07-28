using System; // You are establish the components you'll be using in Unity //
using System.Collections;
using System.Collections.Generic; // You'll be using a Generic collection of components for the UnityEngine //
using UnityEngine;
using CodeMonkey.Utils; // You are using the CodeMonkey utility package //

public class LevelSystemAnimated { // The point of this class is to animate the level system within the game //
	// Don't forget that this is a 'public' class because it will be shown during the game //
	
	public event EventHandler OnExperienceChanged; // You are setting a public event variable, which is a public variable meant to trigger an event once required variables have been put into place //
	public event EventHandler OnLevelChanged; // In this case, you are attempting to trigger the public events in relation to the animated changes in levels and experience //
	
	private LevelSystem levelSystem; // In this series of private variables, you are setting the levelSystem as a start //
	private bool isAnimating; // This boolean variable is an updating variable that is meant to work along the animation while it's updating with it's particle and texture effects //
	private float updateTimer; // The float variable has a series of numbers that updates along a Timer in correlation to the animated levelSystem //
	private float updateTimerMax; // This float variable is meant to continuously use its set of numbers to updateTimer to it's maximum integer //
	
	private int level; // You are setting the private integer for the levels in the leveling system //
	private int experience; // You are setting the private integer for the experience in the leveling system //
	
	public LevelSystemAnimated(LevelSystem levelSystem) { // You are using the private integers, booleans, and floats to connect them under public variable LevelSystemAnimated //
		this.levelSystem = levelSystem; // You are confirming that the levelSystem is functioning as a levelSystem //
		
		level = levelSystem.GetLevelNumber(); // You are asking the private integer 'level' to obtain a new number when //
		experience = levelSystem.GetExperience(); // the required experience is intact to update the level, which is done through the function levelSystem.GetExperience //
		
		levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged; // As the required experience changes the level, the levelSystem changes with the ExperienceChanged //
		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged; // When the level changes alongside the levelSystem, there is a confirmation that the level has changed using '+=' //
	}
	
	private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e) { // You are sending an animated object to changed the LevelSystem //
		isAnimating = true; // You are confirming that it's true for levelSystem to animated, by revealing isAnimating = true //
	}
	
	private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e) { // You are repeating the same line of code twice to confirm that there won't be any errors //
		isAnimating = true; // You are confirming that it's true for levelSystem to animated, by revealing isAnimating = true //
	}
	
	private void Update() { // This private void variable is meant to manage the updating factor of the animation //
		if (isAnimating) { // If the levelSystem is animating //
			// CHeck if its time to update
			updateTimer += Time.deltaTime; // Update the timer for the variable Time.deltaTime //
			while (updateTimer > updateTimerMax) { // If the updatedTimer integer is greater than the maximum updated time integer reached //
				// Time to update
				updateTimer -= updateTimerMax; // Subtracted the updated timer updateTimer from the maximum time integer updateTimerMax //
				UpdateAddExperience(); // As a result, update the newly added experience in correlation to the timer //
			}
		}
	}
	
	private void UpdateAddExperience() { // This private void is meant to update the added experience once the Time variables have been triggered //
		if (level < levelSystem.GetLevelNumber()) { // If the level is less than the required level to get to the next level //
			// Local level under target level
			AddExperience(); // Add experience as a result to get to the next level, once the required experience is gained //
		} else { // Otherwise //
			// Local level equals the target level
			if (experience < levelSystem.GetExperience()) { // If the required experience is less than the required experience to enter new level //
				AddExperience(); // Add experience to get to the next level //
			} else { // Otherwise //
				isAnimating = false; // Don't trigger an animation //
			}
		}
	}
	
	private void AddExperience() { // This private void is meant to handle the addition of experience within the game //
		experience++; // The process of adding the experience //
		if (experience >= levelSystem.GetExperienceToNextLevel(level)) { // If the experience is greater than or equal to the needed experience to get to the next level //
			level++; // Increase the level //
			experience = 0; // Set the experience to 0 at the new level //
			if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty); // If the level hasn't changed in response to the experience gained, don't do anything //
		}
		if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty); // Repeat this line of code to confirm //
	}
	
	public int GetLevelNumber() { // This public integer is to show the new level once the level has been reached //
		return level; // You are returning the level for it to be seen //
	}
	
	public float GetExperienceNormalized() { // You must normalize the process of getting experience through a float variable (a float variable consists of various numbers //
		if (levelSystem.IsMaxLevel(level)) { // If the levelSystem has reached the maxLevel //
			return 1f; // Return 1 point to avoid any errors //
		} else { // Otherwise //
			return (float)experience / levelSystem.GetExperienceToNextLevel(level); // Make the float variable do nothing //
		}
	}
}
	
	
