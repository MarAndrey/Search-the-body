using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    void Update()
    {
        OpenCloseSettings();
        SensivityXText();
        SensivityYText();
    }

    private bool isFullScreen = false;

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    [SerializeField] private GameObject _settings;
    public void OpenCloseSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settings.SetActive(false);
        }
    }


    public void SensivityX(float sliderValueX)
    {
        CameraFollowing._sensivity = sliderValueX; 
    }

    /*public void SensivityY(float sliderValueY)
    {
        CameraFollowing._sensivityX = sliderValueY;
    }*/

    public TextMeshProUGUI sensivityXText;
    public void SensivityXText()
    {
        sensivityXText.text = CameraFollowing._sensivity.ToString("0.00");
    }

    public TextMeshProUGUI sensivityYText;
    public void SensivityYText()
    {
        sensivityYText.text = CameraFollowing._sensivity.ToString("0.00");
    }
}
