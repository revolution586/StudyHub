package Project2;

import java.awt.EventQueue;
import javax.swing.JFrame;

public class Project2 extends JFrame {
	
	public Project2() {
		
		initUI();
	}
	
	private void initUI() {
		
		add(new Board());
		
		setTitle("Atheros");
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setSize(380, 420);
		setLocationRelativeTo(null);
	}
	
	public static void main(String[] args) {
		
		EventQueue.invokeLater(() -> {
			Project2 ex = new Project2();
			ex.setVisible(true);
		});
	}
}
