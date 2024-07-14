using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public void ChangeResolutionScreen(int indexRes)
    {
        switch (indexRes)
        {
            case 0:
                Debug.Log("���������� �������� �� 1280x720");
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 1:
                Debug.Log("���������� �������� �� 1920x1080");
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 2:
                Debug.Log("���������� �������� �� 2560x1440");
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
        }
    }

    public void SelectFullScreen(int indexScreen)
    {
        switch (indexScreen)
        {
            case 0:
                Debug.Log("� ������ �����");
                Screen.fullScreen = true;
                break;
            case 1:
                Debug.Log("������� �����");
                Screen.fullScreen = false;
                break;
        }
    }
}
