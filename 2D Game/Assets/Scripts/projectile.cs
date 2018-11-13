using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float Speed;
    public float TimeOut;
    public GameObject Player;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        EnemyDeath = Resources.Load("Prefabs/DeathP") as GameObject;
        ProjectileParticle = Resources.Load("Prefabs/RespawnP") as GameObject;
        //Player = FindObjectOfType<Rigidbody2D>();
        if (Player.transform.localScale.x < 0)
            Speed = -Speed;

        Destroy(gameObject, TimeOut);

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.addPoints(PointsForKill);
        }


        Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
