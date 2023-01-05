using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other) {
    switch(other.gameObject.tag) {
      case "Friendly":
        Debug.Log("I'm friendly");
        break;
      case "Finished":
        LoadNextLevel();
        break;
      case "Fuel":
        Debug.Log("Fuel Added!");
        break;
      default:
        ReloadLevel();
        break;
    }
  }

    void ReloadLevel() {
      //Gets the scene we are currently on.
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex = currentSceneIndex + 1;
      if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
        nextSceneIndex = 0;
      }
      SceneManager.LoadScene(nextSceneIndex);
    }
}
