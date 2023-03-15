using UnityEngine;

public class Paddle : MonoBehaviour
{
	// Speed variable 
	[SerializeField]
	private float speed = 0.01f;
	
    // Start is called before the first frame update
    void Start(){
        // Set the colors for left and right paddles
		if(transform.CompareTag("leftPaddle")){
			
			  GetComponent<SpriteRenderer>().color = new Color(1, 0,0);
		}
		else if(transform.CompareTag("rightPaddle")){
			
			  GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
		}
    }

    // Update is called once per frame
    void Update(){
		// Set movement for both paddles
		// left paddle -> w,s		right paddle -> up/down arrow keys 
		if (transform.CompareTag("leftPaddle")) {
           
			if (Input.GetKey(KeyCode.W)) {
				transform.Translate(Vector3.up * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.S)) {
				transform.Translate(-Vector3.up * speed * Time.deltaTime);
			}
		}
		else if (transform.CompareTag("rightPaddle")){
       
			if (Input.GetKey(KeyCode.UpArrow)) {
				transform.Translate(Vector3.up * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				transform.Translate(-Vector3.up * speed * Time.deltaTime);
			}
		}
		
        
    }

    void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.CompareTag("topWarp")) {
			transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
		}

        else if (c.gameObject.CompareTag("bottomWarp")) {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }
    }
}
