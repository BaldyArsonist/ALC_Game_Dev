using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    private Rigidbody2D Player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;

    public int pointPenaltyOnDeath;

    private float gravityStore;
	// Use this for initialization
	void Start () {

        Player = FindObjectOfType<Rigidbody2D>();
	}
	
    public void RespawnPlayer(){
        StartCoroutine ("RespawnPCCo");
    }

    public IEnumerator RespawnPlayerCo(){
        Instantiate(deathParticle, Player.transform.position, Player.transform.rotation);
        //Player.enabled = false;
        Player.GetComponent<Renderer>().enabled = false;

        //gravity reset
        gravityStore = Player.GetComponent<Rigidbody2D>().gravityScale;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //point penalty
        ScoreManager.addPoints(-pointPenaltyOnDeath);
        //debug message
        Debug.Log("Player Respawn");
        //respawn delay
        yield return new WaitForSeconds(respawnDelay);
        //gravity restore
        Player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //match players transform position
        Player.transform.position = currentCheckPoint.transform.position;
        //showPlayer
        Player.GetComponent<Renderer>().enabled = true;
        //spawn Player
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);



    }
	// Update is called once per frame
	void Update () {
		
	}
}
