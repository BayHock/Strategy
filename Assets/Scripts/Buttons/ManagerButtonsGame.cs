using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtonsGame : MonoBehaviour
{
    public void LoadSceneMenu()
    {
        Debug.Log("������ ������ ������ � ������� ����");
        SceneManager.LoadScene("MainMenu");
    }
}
