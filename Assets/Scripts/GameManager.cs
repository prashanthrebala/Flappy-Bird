using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject getReady;
    public GameObject gameOver;
    public Player player;

    private void Awake() {
        gameOver.SetActive(false);
        Application.targetFrameRate = 60;
        scoreText.enabled = false;
        getReady.SetActive(true);
        Pause();
    }

    public void Play() {
        player.transform.position = Vector3.zero;
        player.velocity = Vector3.zero;
        SetScore(0);
        Time.timeScale = 1f;
        player.enabled = true;
        scoreText.enabled = true;
        playButton.SetActive(false);
        getReady.SetActive(false);
        gameOver.SetActive(false);

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
        playButton.SetActive(true);
    }

    public void Update() {
        if(playButton.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            Play();
        }
    }

    public void IncreaseScore() {
        SetScore(++score);
    }

    public void GameOver() {
        Pause();
        gameOver.SetActive(true);
    }

    private void SetScore(int score) {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

}
