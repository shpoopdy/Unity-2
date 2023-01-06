using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float levelLoadDelay = 1f;
  [SerializeField] AudioClip crash;
  [SerializeField] AudioClip success;

  [SerializeField] ParticleSystem crashParticles;
  [SerializeField] ParticleSystem successParticles;

  AudioSource audioSource;

  bool isTransitioning = false;

  void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnCollisionEnter(Collision other) {

    if (isTransitioning) return;

    switch(other.gameObject.tag) {
      case "Friendly":
        Debug.Log("I'm friendly");
        break;
      case "Finished":
        NextLevelSequence();
        break;
      default:
        StartCrashSequence();
        break;
    }
  }

  void StartCrashSequence() {
    crashParticles.Play();
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crash);
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", levelLoadDelay);
  }

  void NextLevelSequence() {
    successParticles.Play();
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(success);
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", levelLoadDelay);
  }

  void ReloadLevel() {
    //Gets the scene we are currently on.
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void LoadNextLevel() {
    isTransitioning = false;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
      nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
  }
}
