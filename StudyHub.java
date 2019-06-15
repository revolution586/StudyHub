package StudyHub;

import java.event.KeyEvent;
// Error - Instead, java.event.KeyEvent which should be in the board, you add java.awt.EventQueue //
import javax.swing.JFrame;

public class StudyHub extends JFrame {
  
  // public Pacman() {
  // You must add this after you declare the public class //
  
  add (new Board);
  // add (new Board) doesnt come after the declaration of the public class //
	// It comes after private void initUI() { //
	// Also, add an extra two bracks, add (new Board()); // 
	
  init();
  // It's initUI(), and it belongs under public Pacman () {
  // public Pacman() {
	//			init();
  /// }
  
	//
  setSize(380, 480);
  DefaultCloseOperation (EXIT_ON_CLOSE);
	// You forgot to add 'set' in front of DefaultCloseOperation //
	// You didn't add setLocationRelativeTo(null);
  setTitle ("StudyHub");
	// This set of variables belongs under private void initUI() { //
	// 
  }
 
private void initUI() {
  
	// add (new Board()) goes here //
	// add setSize, setDefaultCloseOperation(EXIT_ON_CLOSE), setTitle, and setLocationRelativeTo(null) here //

// Set a public static void main(String[] args) variable here //
	// Assign the following code
	// EventQueue.invokeLater(() -> {
  Application ex = new Application;
	// This command must have 'Application' replaced with 'StudyHub' as thats the name of the program //
	// Add brackets beside this command, Application ex = new Application();
	// Under StudyHub ex = new StudyHub();, insert ex.setVisible(true); 
	// Follow this command by }); , } x 2 //
  
  
