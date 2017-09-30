using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float xMin, xMax, yMin, yMax;

	//Used for the Flip() function
	public bool facingRight = true;

	//i.e. Speed
	public float moveForce;
	public float maxSpeed;

	public float speed;

	//Rigidbody2D reference
	private Rigidbody2D rb;

	public Collider2D[] attackHitboxes;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Punch")) 
		{
			Attack (attackHitboxes [0]);
		}

		if (Input.GetButton ("Kick")) 
		{
			Attack(attackHitboxes[1]);
		}

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.velocity = movement * speed;

		//Flips when hitting 'right' and facing left
		if (moveHorizontal > 0 && !facingRight)
			Flip ();
		//Flips when hitting 'left' and facing right
		else if (moveHorizontal < 0 && facingRight)
			Flip ();

		//Restricts player movement to the edges of the screen
		rb.position = new Vector2 
		(
			Mathf.Clamp(rb.position.x, xMin, xMax),
			Mathf.Clamp(rb.position.y, yMin, yMax)
		);
	}

	private Collider2D Attack (Collider2D col)
	{
		//col.OverlapCollider ();
		Collider2D collision = Physics2D.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation.x, LayerMask.GetMask("Enemy"));

		if(collision.gameObject.CompareTag("Enemy"))
			Debug.Log (collision.gameObject.name);

		return collision;
	}

	//Changes rotation of the player
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
