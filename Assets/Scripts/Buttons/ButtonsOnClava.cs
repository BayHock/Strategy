using UnityEngine;

public class ButtonsOnClava : MonoBehaviour
{
    [Header("WindowsInScene")]
    [SerializeField] private GameObject firstWindow;
    [SerializeField] private GameObject secondWindow;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            firstWindow.SetActive(false);
            secondWindow.SetActive(true);
        }
    }
}
