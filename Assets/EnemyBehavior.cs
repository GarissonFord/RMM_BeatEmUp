using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{

	//SpriteRenderer
	private SpriteRenderer sr;
	public int sortOrder;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Updates the order in the plane based on y-position
		updateSortOrder ();
	}

	private void updateSortOrder()
	{
		int yPos = (int) transform.position.y;
		sortOrder = yPos;
		sr.sortingOrder = sortOrder;
	}
}
