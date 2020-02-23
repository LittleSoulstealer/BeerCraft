using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject controls;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject quitScreen;
    [SerializeField] MonsterSpawner monsterSpawnerPrefab;
    MonsterSpawner monsterSpawner;

    public bool isGameOver;
    bool isInPauseMenu;
    PlayerController player;
    public PlayerController playerPrefab;
    [SerializeField] Timer timer;
    public Score score;
     Text gameOverScore;
    bool isQuitting;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        monsterSpawner = Instantiate(monsterSpawnerPrefab);
        monsterSpawner.gameObject.SetActive(false);
        gameOverScore = gameOver.GetComponentInChildren<Text>();
     
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        RestartGame();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameQuitting();
        }
        if(isQuitting&& !isInPauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Quit");
                // Application.Quit();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                isQuitting = false;
                quitScreen.SetActive(false);
                pauseScreen.SetActive(false);
                isInPauseMenu = false;
                Time.timeScale = 1f;
            }
        }
    }

    void RestartGame()
    {
        if (isInPauseMenu && !isQuitting && Input.GetKeyDown(KeyCode.R))
        {
            isInPauseMenu = false;
            player = Instantiate(playerPrefab);
            player.ResetCharacter();
            timer.ResetTimer();
            pauseScreen.SetActive(false);
            isGameOver = true;
            monsterSpawner.gameObject.SetActive(true);
            RPGCameraManager.sharedInstance.virtualCamera.Follow = player.transform;
            monsterSpawner.KillAllMonsters();
            score.value = 0;
            Time.timeScale = 1f;
        }

    }

    public void PauseGame()
    {
        if((!isInPauseMenu&&(player==null||player.isKilled)&&!isQuitting))
        {
            isInPauseMenu = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
           
                if (isGameOver)
                {
                    gameOver.SetActive(true);
                    controls.SetActive(false);
                    gameOverScore.text = "Your score: " + score.value;
                 
                }
                else
                {
                    gameOver.SetActive(false);
                    controls.SetActive(true);
                }
                  
        }
    }
 public void GameQuitting()
    {
        pauseScreen.SetActive(true);
        gameOver.SetActive(false);
        controls.SetActive(false);
        quitScreen.SetActive(true);
        isQuitting = true;
        isInPauseMenu = false;
        Time.timeScale = 0f;
        
    }

}
