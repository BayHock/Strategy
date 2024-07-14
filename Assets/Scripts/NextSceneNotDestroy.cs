using UnityEngine;

public class NextSceneNotDestroy : MonoBehaviour
{
    [SerializeField] private string createdTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this.createdTag);

        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
