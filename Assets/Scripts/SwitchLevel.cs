using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public void SwitchToScene(int index)
    {
        if (index < 0 || index >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError($"Uncorrect index: {index}");
            return;
        }
        SceneManager.LoadScene(index);
    }

    public void SwitchToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchToNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex <= maxSceneIndex ? nextSceneIndex : 0);
    }

    public void SwitchToPreviousScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        int previouSceneIndex = currentSceneIndex - 1;

        SceneManager.LoadScene(previouSceneIndex >= 0 ? previouSceneIndex : maxSceneIndex);
    }
}
