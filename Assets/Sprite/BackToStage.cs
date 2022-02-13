using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToStage : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Stage"));
    }
}
