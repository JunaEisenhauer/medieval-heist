using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject story;

    public void Play()
    {
        startMenu.SetActive(false);
        story.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        if (story.activeSelf && Input.GetButtonDown("Submit"))
        {
            startMenu.SetActive(true);
            story.SetActive(false);
        }
    }
}
