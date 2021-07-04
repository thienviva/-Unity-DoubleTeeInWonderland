using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Rigidbody2D player;
    public Animator anim;
    public GameMaster GM;


    //vị trí
    public float player_x;
    public float player_y;
    public bool faceright = true;

    //đoạn đường di chuyển
    float distant_x = 1.6f;
    float distant_y = 1.5f;

    //chạy animation attack
    public bool IsAttack = false;
    public bool IsDead = false;
    public float Attack_Delay = 0.3f;
    public float Die_Delay = 0.3f;

    //kiểm tra vật cản
    public string top_bound = "none";
    public string bottom_bound = "none";
    public string left_bound = "none";
    public string right_bound = "none";

    //Âm thanh của nhân vật
    public AudioSource aus;
    public AudioClip die;
    public AudioClip atk;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        Get_position();
	}
	
	// Update is called once per frame
	void Update () {
        Controller();
        Get_position();
        
        if (IsAttack)
        {
            if (Attack_Delay > 0) Attack_Delay -= Time.deltaTime;
            else IsAttack = false;



            if(aus && atk)
            {
                aus.PlayOneShot(atk);
            }
        }
        anim.SetBool("Attack", IsAttack);
        if (IsDead)
        {
            if (Die_Delay > 0) Die_Delay -= Time.deltaTime;
            else
            {
                Death();
                IsDead = false;

            }

            if (aus && die)
            {
                aus.PlayOneShot(die);
            }
        }
        anim.SetBool("Die", IsDead);
    }

    void Get_position()
    {
        player_x = player.position.x;
        player_y = player.position.y;
    }
    void PlayerMove(string direction)
    {
        Vector2 position;
        position = transform.localPosition;
        if (direction == "d")
        {
            if (bottom_bound == "none")
            {
                position.y -= distant_y;
                GM.steps--;
            }
            else if (bottom_bound == "monster" || bottom_bound == "crate")
            {
                Attack_Delay = 0.3f;
                IsAttack = true;
                GM.steps--;
            }
        }
        else if (direction == "l")
        {
            if (left_bound == "none")
            {
                position.x -= distant_x;
                GM.steps--;
            }
            else if (left_bound == "monster" || left_bound == "crate")
            {
                Attack_Delay = 0.3f;
                IsAttack = true;
                GM.steps--;
            }
        }
        else if (direction == "u")
        {
            if (top_bound == "none")
            {
                position.y += distant_y;
                GM.steps--;
            }
            else if (top_bound == "monster" || top_bound == "crate")
            {
                Attack_Delay = 0.3f;
                IsAttack = true;
                GM.steps--;
            }
        }
        else if (direction == "r")
        {
            if (right_bound == "none")
            {
                position.x += distant_x;
                GM.steps--;
            }
            else if (right_bound == "monster" || right_bound == "crate")
            {
                Attack_Delay = 0.3f;
                IsAttack = true;
                GM.steps--;
            }
        }

        transform.localPosition = position;
     
        Get_position();
    }
    void Controller()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove("d");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (faceright)
            {
                Flip();
            }
            else
            {
                PlayerMove("l");
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove("u");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!faceright)
            {
                Flip();
            }
            else
            {
                PlayerMove("r");
            }
        }
    }

    //Xoay nhân vật
    void Flip()
    {
        faceright = !faceright;
        //xoay nhân vật
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    //xử lý nếu nhân vật chết
    public void Death()
    {
        GM.gameover.SetActive(true);
        if(PlayerPrefs.GetInt("highscore") < GM.Points)
        {
            PlayerPrefs.SetInt("highscore", GM.Points);
        }
    }
}
