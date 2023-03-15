using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // UI for scoreboard
public class Ball : MonoBehaviour
{
	// Scoreboard UI
	public TextMeshProUGUI txtLeftScore;
	public TextMeshProUGUI txtRightScore;
	
	// Movement speed 
	 public float speed = 4;
	 
	 // Starting direction
	 public Vector2 dir;
	 
	 // Starting position
	 private Vector2 origPos;
	 
	 // Scoreboard values
	 private int leftScore;
	 private int rightScore;
   
    // Start is called before the first frame update
    void Start()
    {
		// Reset the scoreboard
		leftScore = rightScore = 0;
		txtLeftScore.text = leftScore.ToString();
		txtRightScore.text = rightScore.ToString();
		
		// Set the color of the ball 
		 GetComponent<SpriteRenderer>().color = new Color(0,1,0);
		 
		 // Get the original position for restart
		 origPos = transform.position;
		 
		// Randomly select right/left
		float result = Random.Range(0f,1f);
		if(result < 0.5){
			dir = Vector2.left;
		}
		else{
			dir = Vector2.right;
		}
		
		// Randomly select up or down
		result = Random.Range(0f,1f);
		if(result < 0.5){
			dir.y = 1;
		}
		else{
			dir.y = -1;
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
	
	// Handles collision with game boundaries
	void OnCollisionEnter2D(Collision2D c){
		
		// Paddle (left/right)
		if(c.gameObject.transform.tag.EndsWith("Paddle")){
			dir.x *= -1;
		}
		else if(c.gameObject.CompareTag("topBottomBoundary")){
			dir.y *= -1;
		}
		else if(c.gameObject.CompareTag("leftBoundary")){
			// Increase right score
			rightScore++;
			txtRightScore.text = rightScore.ToString();
			
			// Restart game
			transform.position = origPos;
		}
		else if (c.gameObject.CompareTag("rightBoundary")){
			// Increase left score
			leftScore++;
			txtLeftScore.text = leftScore.ToString();
			
			// Restart game
			transform.position = origPos;
		}
		
		
		/*        Win or Game Over Scenarios        */
		// 7 - 0 skunk
		if((leftScore == 7 &&  rightScore == 0) || (rightScore == 7 && leftScore == 0)){
			print("Game Over");
		}
		// Maximum points reached 
		else if(leftScore == 10 || rightScore == 10){
			print("Game Over");
		}
		// Timer elapsed
		
		
	}
}
