using UnityEngine;
using UnityEngine.UI;

public class ManagerButtonProlog : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] private SceneChange sceneChange;

    [Header("ButtonsGame")]
    [SerializeField] private Button fButton;

    private void Start()
    {
        fButton.onClick.AddListener(delegate { ButtonPress("Нажата кнопка начала игры"); LoadSceneGame(); });
    }
    private void ButtonPress(string message)
    {
        Debug.Log(message);
    }
    private void LoadSceneGame()
    {
        sceneChange.CallDelayScene();
    }
}
