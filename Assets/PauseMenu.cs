using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject controls;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] MonsterSpawner monsterSpawnerPrefab;
    MonsterSpawner monsterSpawner;

    public bool isGameOver;
    bool isInPauseMenu;
    PlayerController player;
    public PlayerController playerPrefab;
    [SerializeField] Timer timer;
    public RPGCameraManager camMenager;
    public Score score;
     Text gameOverScore;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        monsterSpawner = Instantiate(monsterSpawnerPrefab);
        monsterSpawner.gameObject.SetActive(false);
        gameOverScore = gameOver.GetComponentInChildren<Text>();
        gameOverScore.text = "aaa";
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        RestartGame();
    }

    void RestartGame()
    {

        if (isInPauseMenu && Input.GetKeyDown(KeyCode.R))
        {
            isInPauseMenu = false;
            player = Instantiate(playerPrefab);
            player.ResetCharacter();
            timer.ResetTimer();
            pauseScreen.SetActive(false);
            isGameOver = true;
            monsterSpawner.gameObject.SetActive(true);
            camMenager.virtualCamera.Follow = player.transform;
            monsterSpawner.KillAllMonsters();
            score.value = 0;
            Time.timeScale = 1f;

        }

    }

    public void PauseGame()
    {
        if(!isInPauseMenu&&(player==null||player.isKilled))
        {
            isInPauseMenu = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;

            if (isGameOver)
            {
                gameOver.SetActive(true);
                controls.SetActive(false);
                gameOverScore.text = "Your score: " + score.value;
                WaitAfterDeath();
            }
            else
            {
                gameOver.SetActive(false);
                controls.SetActive(true);
            }
            
        }


    }

    IEnumerator WaitAfterDeath()
    {
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
