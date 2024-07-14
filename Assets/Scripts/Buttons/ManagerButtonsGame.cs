using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtonsGame : MonoBehaviour
{
    public void LoadSceneMenu()
    {
        Debug.Log("Нажата кнопка выхода в главное меню");
        SceneManager.LoadScene("MainMenu");
    }
}
