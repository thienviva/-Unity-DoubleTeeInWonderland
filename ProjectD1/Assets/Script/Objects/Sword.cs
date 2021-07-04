using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameMaster GM;
    public float lifetime = 5;



    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

        lifetime -= Time.deltaTime;
        if (lifetime <= 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) GM.steps -= 1;
    }
}
