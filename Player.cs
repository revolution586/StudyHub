//This is just some code to make a player, it was taken from CodeMonkey.com but I'm not really copying it, I just want to know what the guy did because the tutorial sucked :) //
using System; // As always, it is important to set a couple of variables before you begin //
using UnityEngine; // To make an animated player, you need to use V_AnimationSystem and the CodeMonkey.Utils pack //
using V_AnimationSystem; 
using CodeMonkey.Utils;

public class Player : MonoBehaviour { // Every player in any game needs a private variable to them. //
 
 [SerializeField] private Transform pfEffect; // For this private variable, you are using the particle effect for the player with Transform component. The Transform component uses Vector2D and Vector3D variables. //
 [SerializeField] private Texture2D baseTexture; // The baseTexture is a Texture2D variable meant to input the torso of the character //
 [SerializeField] private Texture2D headTexture; // The headTexutre is a Texture2D variable meant to input the head of the character //
 [SerializeField] private Texture2D helmet1Texture; // Because this player will be using items, there will be two textured assets, helmet1 and helmet2 //
 [SerializeField] private Texture2D helmet2Texture;
 
 private Player_Base playerBase; // Aside from setting the 2D textures, you must also set the materials for the player //
 private Material material; // This private variable is meant to connect Materials to the character //
 private Color materialTintColor; // Because materials are associated with materialTintColor, you must establish a color for the player //
 private LevelSystemAnimated levelSystemAnimated; // Because the player is animated, you must set a levelSystemAnimated variable //
 
 public enum Equip { // public enum is a public variable that is meant to make sure the items you have in the game are to be equipped //
  None, // There is no private data stored into these variables //
  Helmet_1, // Because you'll be equipping certain items in the game, these items will include the two helmets mentioned earlier //
  Helmet_2,
 }
 
 private void Awake() { // 'private void Awake' is a private variable that makes the equipping, player objects, and materials move into action //
  playerBase = gameObject.GetComponent<Player_Base>(); // To initiate the playerBase, you need to initiate the component that holds the variable using gameObject.GetComponent<Player_Base> //
  material = transform.Find("Body").GetComponent<MeshRenderer>().material; // To make sure all materials work in correlation to the body of the player, you need to initiate the MeshRenderer that holds the component of the moving materials //
  materialTintColor = new Color(1, 0, 0, 0); // To make sure the TintColor variable is activated, you must pinpoint all the colors //
  SetEquip(Equip.None); // The SetEquip variable is meant to set up the equipping action of the game, at which the player wears the material assets such as Helmet1 and Helmet2 //
 }
 
 private void Update() { // After everything becomes active under 'private void Awake', there needs to be an updating factor while the game is running, hence why we choose 'private void Update' //
  if (materialTintColor.a > 0) { // If the materialTintColor is greater than 0 //
   float tintFadeSpeed = 6f;  //Make the color 6f at a fading speed //
   materialTintColor.a -= tintFadeSpeed * Time.deltaTime; // Multiplying tintFadeSpeed by the time it takes for the fading of the color to happen //
   material.SetColor("_Tint", materialTintColor); // You need to make the system realize what color you're setting by a name //
  }
 }
 
 public void SetLevelSystemAnimated(LevelSystemAnimated levelSystemAnimated) { // Any animated variable must be a public variable to make it show during the game //
  this.levelSystemAnimaed = levelSystemAnimated; // This code is used to confirm the levelSystemAnimated variable //
  
  levelSystemAnimated.OnLevelChanged += LevelSystem_OnLevelChanged; // This piece of code is meant to establish that the animation and the change in the game level is correlated //
 }
 
 private void LevelSystem_OnLevelChanged(object sender, EventArgs e) { // For this private variable, the point is to activate different variables as the level changes //
  PlayVictoryAnim(); // One of the important variables, is playing a Victory animation through PlayVictoryAnim() once the level changes //
  SpawnParticleEffect(); // Another variable is for the particle effect to initiate after the change in levels //
  Flash(new Color(1, 1, 1, 1)); // With every particle effect, there comes a series of colors (1, 1, 1, 1) that must be initiated //
  
  SetHealthBarSize(1f + levelSystemAnimated.GetLevelNumber() * .1f); // The healthbar, especially it's size, is an important component of every game. //
 } // In this situation, you are setting the HealthBarSize to increase by 1f (1 level point) once there is a update in the level, which is done through levelSystemAnimated.GetLevelNumber)
 
 public Vector3 GetPosition() {
  return transform.position; // You are transforming the 2D position of the character using Vector3 GetPosition //
 }
 
 private void PlayVictoryAnim() {
  playerBase.PLayVictoryAnim(); // You are reminding the game to correlate the playerBase with the Victory animation //
 }
 
 private void SpawnParticleEffect() { // When it comes to spawning a particle effect, there are two aspects, transforming the effect, and destroying the particles in response to the time //
  Transform effect = Instantiate(pfEffect, transform); // In this piece of code, you are initiating the Particle effect //
  FunctionTimer.Create(() => Destroy(effect.gameObject), 3f); //In under 3 seconds using 3f, you are destroying the set of particles within that spectrum of time //
 }
 
 private void Flash(Color flashColor) { // Because flashing colors are an important component after a victory animation in response to particle response time, connecting materialTintColor and flashColor are important in making that happen //
  materialTintColor = flashColor; // Here, you are telling the system to put materialTintColor and flashColor together //
  material.SetColor("_Tint", materialTintColor); // You are once again setting the TintColor for the material // 
 }
 
 private void SetHealthBarSize(float healthBarSize) { // The point of setting this healthBarSize is to animate it using Vector3 components //
  transform.Find("healthBar").localScale = new Vector3(.7f * healthBarSize, 1, 1); // Here, you are telling the healthBar to transform the scale of the healthbar by .7f (.7f * healthBarSize) //
  // You are also using the colors 1, 1 in the process //
 }
 
 public void SetEquip(Equip equip) { // For this public void variable, you are equipping the 2D textures and its formats used for Helmet1 and Helmet 2 //
  Texture2D texture = new Texture2D(512, 512, TextureFormat.RGBA32, true); // To make sure textures are equipped under a sizable format, you must set the dimensions under TextureFormat.RGBA32 to 512x512, and establish this as true //
  
  Color[] spritesheetBasePixels = baseTexture.GetPixels(0, 0, 512, 512); // In order to set the dimensions of baseTexture, you must set the spiresheetBasePixels to the dimension of 512,512 as well //
  texture.SetPixels(0, 0, 512, 512, spritesheetBasePixels); // What I just mentioned above //
  
  // When you're going to set the dimensions of anything color-related when it comes to assets such as materials and textures, begin the line of code in relation to variable you're changing to Color[] //
  Color[] headPixels;
  switch (equip) {
  default:
  case Equip.None; // By default, you aren't equipping any items //
   headPixels = headTexture.GetPixels(0, 0, 128, 128) // You are setting the dimensions of the headPixels to 128x128 //
   break;
  case Equip.Helmet_1;
   headPixels = helmet1Texture.GetPixels(0, 0, 128, 128); // You are the setting the dimensions of Helmet1 pixels to 128x128 //
   break; //break means pause once the dimensions have been set //
  case Equip.Helmet_2;
   headPixels = helmet2Texture.GetPixels(0, 0, 128, 128); // You are setting the dimensions of Helmet2 pixels to 128x128 //
   break; // break means pause once the dimensions have been set //
  }
  texture.SetPixels(4, 384, 128, 128, headPixels); // To finalize setting all of the dimensions for the pixels, including the headTexture, you must set the dimensions to (4, 384, 128, 128) //
  
  texture.Apply(); // Apply the textures //
  
  material.mainTexture = texture; // Apply the texture component to the mainTexture which is connected to materials through mainTexture //
  
 
