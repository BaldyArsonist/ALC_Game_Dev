using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour {

    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.GetComponent<Rigidbody2D>() == null){
            return;
        }
            
        ScoreManager.addPoints(pointsToAdd);

        Destroy(gameObject);
	}
}
