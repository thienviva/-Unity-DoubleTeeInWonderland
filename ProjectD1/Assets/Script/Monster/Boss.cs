using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Player player;
    public GameMaster GM;
    public Rigidbody2D boss;
    public Animator Banim;
    public GameObject sword;
    public Transform AttackPoint;

    public bool player_nearby = false;
    public bool Die = false;
    public bool Hurt = false;
    public bool Attack = false;
    public float Die_Delay = 0.3f;
    public float Hurt_Delay = 0.3f;
    public float Attackinterval = 3f;
    public float Attacktimer;
    public float Sword_speed = 2f;
    public int HP = 50;

    //Âm thanh của boss
    public AudioSource aus;
    public AudioClip die;
    public AudioClip atk;
    public AudioClip hurt;
    public AudioClip sword_sound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        boss = gameObject.GetComponent<Rigidbody2D>();
        Banim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attacking();
        Banim.SetBool("Boss_die", Die);
        Banim.SetBool("Boss_hurt", Hurt);
        if (player_nearby)
        {
            Check_Hurt();
        }

        if (Hurt)
        {
            if (aus && hurt && player.aus)
            {
                aus.PlayOneShot(hurt);
            }
            if (Hurt_Delay > 0) Hurt_Delay -= Time.deltaTime;
            else
            {
                HP -= 10;
                Hurt = false;
            }


        }
        if (HP == 0)
        {
            if (aus && die && player.aus)
            {
                aus.PlayOneShot(die);
            }
            Die = true;
        }
        if (Die)
        {
            if (Die_Delay > 0) Die_Delay -= Time.deltaTime;
            else
            {
                GM.Points += 5000;
                Destroy(gameObject);
            }
        }
    }

    void Check_Hurt()
    {
        Vector2 position;
        position = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.DownArrow) && player.bottom_bound == "monster" && Mathf.Abs(position.y - player.player_y) > 1)
        {
            Hurt_Delay = 0.3f;
            Hurt = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && player.top_bound == "monster" && Mathf.Abs(position.y - player.player_y) > 1)
        {
            Hurt_Delay = 0.3f;
            Hurt = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.left_bound == "monster" && Mathf.Abs(position.x - player.player_x) > 1)
        {
            Hurt_Delay = 0.3f;
            Hurt = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && player.right_bound == "monster" && Mathf.Abs(position.x - player.player_x) > 1)
        {
            Hurt_Delay = 0.3f;
            Hurt = true;
        }
    }

    void Attacking()
    {
        Attacktimer += Time.deltaTime;
        if (Attacktimer >= Attackinterval)
        {
            if (aus && atk)
            {
                aus.PlayOneShot(atk);
                aus.PlayOneShot(sword_sound);
            }
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            GameObject swordclone;
            swordclone = Instantiate(sword, AttackPoint.transform.position,sword.transform.rotation) as GameObject;
            swordclone.GetComponent<Rigidbody2D>().velocity = direction * Sword_speed;
            Attacktimer = 0;
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
