using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float Speed;
    public Rigidbody2D Player;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;

	// Use this for initialization
	void Start () {
        //Player = FindObjectOfType<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.localScale.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.addPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
