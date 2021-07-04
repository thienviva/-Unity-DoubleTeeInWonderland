using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_top : MonoBehaviour
{
    public Crate crate;
    // Use this for initialization
    void Start()
    {
        crate = gameObject.GetComponentInParent<Crate>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) crate.crate_top = "rock";
        else if (collision.CompareTag("Monster")) crate.crate_top = "monster";
        else if (collision.CompareTag("Crate")) crate.crate_top = "crate";
        else if (collision.CompareTag("Player")) crate.crate_top = "player";
        else if (collision.CompareTag("Limit")) crate.crate_top = "limit";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")) crate.crate_top = "rock";
        else if (collision.CompareTag("Monster")) crate.crate_top = "monster";
        else if (collision.CompareTag("Crate")) crate.crate_top = "crate";
        else if (collision.CompareTag("Player")) crate.crate_top = "player";
        else if (collision.CompareTag("Limit")) crate.crate_top = "limit";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        crate.crate_top = "none";
    }
}
