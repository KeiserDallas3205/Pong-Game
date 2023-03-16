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

	// Audio values
	 public AudioClip[] sounds;
	 private AudioSource audioSrc;
	 
	 // Sprite list
	 public Sprite[] balls;
	 private int rand;
	 
	 // Explosion for wall
	public GameObject goal;
   
    // Start is called before the first frame update
    void Start()
    {
		// Reset the scoreboard
		leftScore = rightScore = 0;
		txtLeftScore.text = leftScore.ToString();
		txtRightScore.text = rightScore.ToString();
		
		// Set the sprite for the ball
		rand = Random.Range(0,balls.Length);
		GetComponent<SpriteRenderer>().sprite = balls[rand];
		
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
		
		// Get audio source
		audioSrc = GetComponent<AudioSource>();
		
       
		
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
			audioSrc.clip = sounds[Random.Range(0, sounds.Length)];
			audioSrc.Play();
		}
		else if(c.gameObject.CompareTag("topBottomBoundary")){
			dir.y *= -1;
		}
		else if(c.gameObject.CompareTag("leftBoundary")){
			// Goal Explosion
			var temp = Instantiate(goal, c.contacts[0].point, Quaternion.identity);
			Destroy(temp, 1.0f);
			// Increase right score
			rightScore++;
			txtRightScore.text = rightScore.ToString();
			
			// Restart game
			transform.position = origPos;
		}
		else if (c.gameObject.CompareTag("rightBoundary")){
			// Goal explosion
			var temp = Instantiate(goal, c.contacts[0].point, Quaternion.identity);
			Destroy(temp, 1.0f);
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
