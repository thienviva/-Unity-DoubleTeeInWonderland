using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    public Rigidbody2D sign;
    public GameMaster GM;
    public Player player;
    public int levelLoad;
    // Start is called before the first frame update
    void Start()
    {
        sign = gameObject.GetComponent<Rigidbody2D>();
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Scene activeScene = SceneManager.GetActiveScene();
        levelLoad = activeScene.buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GM.Points += GM.steps * 500;
            savescore();
            if (levelLoad <= 5)
            {
                SceneManager.LoadScene(levelLoad);
            }
            else GM.win.SetActive(true);
        }
    }

    void savescore()
    {
        PlayerPrefs.SetInt("points", GM.Points);
    }
}
