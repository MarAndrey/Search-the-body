using UnityEngine;

public class ExitWindow : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickResume();
        }
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    [SerializeField] private GameObject _exit;
    public void OnClickResume()
    {
        _exit.SetActive(false);
    }
}
