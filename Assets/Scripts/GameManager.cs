using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int moneyToCollect = 3;

    public GameObject player;
    public EnemySpawner enemySpawner;
    public AudioSource audioSource;
    public string nextLevel;

    public AudioClip wonClip;
    public AudioClip lostClip;

    public GameObject wonScreen;
    public GameObject lostScreen;

    public bool isMapShown;

    private void Awake()
    {
        instance = this;
    }

    public static GameManager Instance()
    {
        return instance;
    }

    public void MoneyDelivered()
    {
        moneyToCollect--;
        if(moneyToCollect <= 0)
        {
            Won();
        }
    }

    public void Won()
    {
        PlaySound(wonClip);

        Time.timeScale = 0f;
        wonScreen.SetActive(true);
    }

    public void Lost()
    {
        PlaySound(lostClip);

        Time.timeScale = 0f;
        lostScreen.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
