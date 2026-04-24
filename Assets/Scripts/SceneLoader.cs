using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToLoad : MonoBehaviour
{
    public string m_SceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(m_SceneToLoad);
    }
}
