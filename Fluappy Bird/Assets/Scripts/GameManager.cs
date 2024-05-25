using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject settingsButton;

    private int score;
    private int coins;
    public int Score => score;
    public int Coins => coins;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
            Pause();
        }
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveCoins();
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        coinText.text = coins.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        shopButton.SetActive(false);
        settingsButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        shopButton.SetActive(true);
        settingsButton.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Lvl");
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score % 10 == 0)
        {
            coins++;
            coinText.text = coins.ToString();
            SaveCoins(); // Сохранение монет при их изменении
        }
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = coins.ToString();
    }
}
