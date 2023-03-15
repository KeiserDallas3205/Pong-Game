using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	// Movement speed 
	 public float speed = 4;
	 // Starting direction
	 public Vector2 dir;
	 // Starting position
	 private Vector2 origPos;
   
    // Start is called before the first frame update
    void Start()
    {
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
			// Restart game
			transform.position = origPos;
		}
		else if (c.gameObject.CompareTag("rightBoundary")){
			// Restart game
			transform.position = origPos;
		}
		
		
		
		
	}
}
