using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

    public Player player;
    public Rigidbody2D crate;

    public bool player_nearby = false;

    //kiểm tra xung quanh
    public string crate_top = "none";
    public string crate_bottom = "none";
    public string crate_left = "none";
    public string crate_right = "none";

    //đoạn đường di chuyển
    float distant_x = 1.6f;
    float distant_y = 1.5f;

    //Âm thanh
    public AudioSource aus;
    public AudioClip push;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        crate = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 location;
        location = transform.localPosition;
		if(player_nearby == true)
        {
            Crate_Move();
        }
	}
    void Crate_Move()
    {
        Vector2 position;
        position = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.DownArrow) && player.bottom_bound == "crate" && crate_top == "player")
        {
            if (aus && push && player.aus)
            {
                aus.PlayOneShot(push);
            }
            if (crate_bottom == "none") position.y -= distant_y;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && player.top_bound == "crate" && crate_bottom == "player")
        {
            if (aus && push && player.aus)
            {
                aus.PlayOneShot(push);
            }
            if (crate_top == "none") position.y += distant_y;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.left_bound == "crate" && player.faceright == false && crate_right == "player")
        {
            if (aus && push && player.aus)
            {
                aus.PlayOneShot(push);
            }
            if (crate_left == "none") position.x -= distant_x;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && player.right_bound == "crate" && player.faceright == true && crate_left == "player")
        {
            if (aus && push && player.aus)
            {
                aus.PlayOneShot(push);
            }
            if (crate_right == "none") position.x += distant_x;
        }
        transform.localPosition = position;
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
