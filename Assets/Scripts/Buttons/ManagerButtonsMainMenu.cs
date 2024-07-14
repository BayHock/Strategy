using UnityEngine;
using UnityEngine.UI;

public class ManagerButtonsMainMenu : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] private SceneChange sceneChange;

    [Header("ButtonsMainMenu")]
    [SerializeField] private Button fButton;
    [SerializeField] private Button sButton;
    [SerializeField] private Button tButton;

    private void Start()
    {
        Screen.fullScreen = true;
        fButton.onClick.AddListener(delegate { ButtonPress("Нажата кнопка начала игры"); LoadSceneStartGame(); });
        sButton.onClick.AddListener(delegate { ButtonPress("Нажата кнопка настроек"); });
        tButton.onClick.AddListener(delegate { ButtonPress("Нажата кнопка выхода из игры"); ExitGame(); });
    }

    private void ButtonPress(string message)
    {
        Debug.Log(message);
    }

    private void LoadSceneStartGame()
    {
        sceneChange.CallDelayScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
