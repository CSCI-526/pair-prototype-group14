using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("开始新游戏...");

        // 先卸载 `Game` 场景，确保它被完整刷新
        if (SceneManager.GetSceneByName("Game").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Game").completed += (op) =>
            {
                Debug.Log("Game 场景已卸载，重新加载...");
                SceneManager.LoadScene("Game");
            };
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void QuitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
