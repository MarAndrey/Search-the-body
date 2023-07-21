using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        OpenExitWindow();
    }

    [SerializeField] private GameObject _exit;
    void OpenExitWindow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _exit.SetActive(true);
        }
    }

    public void OnClickExit()
    {
        _exit.SetActive(true);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
