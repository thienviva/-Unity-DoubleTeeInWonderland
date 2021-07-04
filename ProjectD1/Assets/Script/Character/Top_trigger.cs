using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_trigger : MonoBehaviour {

    public Player player;
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) player.top_bound = "rock";
        else if (collision.CompareTag("Monster")) player.top_bound = "monster";
        else if (collision.CompareTag("Crate")) player.top_bound = "crate";
        else if (collision.CompareTag("Limit")) player.top_bound = "limit";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) player.top_bound = "rock";
        else if (collision.CompareTag("Monster")) player.top_bound = "monster";
        else if (collision.CompareTag("Crate")) player.top_bound = "crate";
        else if (collision.CompareTag("Limit")) player.top_bound = "limit";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.top_bound = "none";
    }
}
