using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public Player player;
    public GameMaster GM;
    public Rigidbody2D monster;
    public Animator Manim;

    public bool player_nearby = false;
    public bool Die = false;
    public float Die_Delay = 0.3f;

    //Âm thanh 
    public AudioSource aus;
    public AudioClip die;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        monster = gameObject.GetComponent<Rigidbody2D>();
        Manim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Manim.SetBool("Monster_die", Die);
        if (player_nearby == true)
        {
            Check_Die();
        }
        if (Die)
        {

            if (aus && die && player.aus)
            {
                aus.PlayOneShot(die);
            }

            if (Die_Delay > 0) Die_Delay -= Time.deltaTime;
            else
            {
                GM.Points += 1000;
                Destroy(gameObject);
            }
        }
    }

    void Check_Die()
    {
        Vector2 position;
        position = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.DownArrow) && player.bottom_bound == "monster" && Mathf.Abs(position.y - player.player_y) > 1)
        {
            Die = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && player.top_bound == "monster" && Mathf.Abs(position.y - player.player_y) > 1)
        {
            Die = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.left_bound == "monster" && Mathf.Abs(position.x - player.player_x) > 1)
        {
            Die = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && player.right_bound == "monster" && Mathf.Abs(position.x - player.player_x) > 1)
        {
            Die = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Trigger")) player_nearby = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Trigger")) player_nearby = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player_nearby = false;
    }
}
