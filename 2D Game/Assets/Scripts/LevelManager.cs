using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    private Rigidbody2D player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;

    public int pointPenaltyOnDeath;

    private float gravityStore;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Rigidbody2D>();
	}
	
    public void RespawnPlayer(){
        StartCorountine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        player.enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        ScoreManager.addPoints(-pointPenaltyOnDeath);

        Debug.Log("Player Respawn");

        yield return new WaitForSeconds(respawnDelay);

        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
