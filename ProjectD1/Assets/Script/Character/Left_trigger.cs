using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_trigger : MonoBehaviour {

    public Player player;
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Scale;
        Scale = transform.localScale;
        if (player.faceright == false)
        {
            Scale.x = -1;
        }
        else Scale.x = 1;
        transform.localScale = Scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) player.left_bound = "rock";
        else if (collision.CompareTag("Monster")) player.left_bound = "monster";
        else if (collision.CompareTag("Crate")) player.left_bound = "crate";
        else if (collision.CompareTag("Limit")) player.left_bound = "limit";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) player.left_bound = "rock";
        else if (collision.CompareTag("Monster")) player.left_bound = "monster";
        else if (collision.CompareTag("Crate")) player.left_bound = "crate";
        else if (collision.CompareTag("Limit")) player.left_bound = "limit";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.left_bound = "none";
    }
}
