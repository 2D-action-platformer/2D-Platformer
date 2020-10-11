using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight= 5f;
    private Rigidbody2D rb2d;
    int playerLayer, platformLayer;
    bool jumpOffCoroutineIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        playerLayer = LayerMask.NameToLayer ("Player");
		platformLayer = LayerMask.NameToLayer ("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        float Dirx = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + Dirx, transform.position.y);
        if(Input.GetButtonDown("Jump") && !Input.GetKey (KeyCode.DownArrow) && rb2d.velocity.y == 0) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
        else if(Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.DownArrow) && rb2d.velocity.y == 0)
        {
            StartCoroutine ("JumpOff");
        }
        if (rb2d.velocity.y > 0)
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		
		else if (rb2d.velocity.y <= 0 && !jumpOffCoroutineIsRunning)
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    }
    IEnumerator JumpOff()
	{
		jumpOffCoroutineIsRunning = true;
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		yield return new WaitForSeconds (0.5f);
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
		jumpOffCoroutineIsRunning = false;
	}
}
