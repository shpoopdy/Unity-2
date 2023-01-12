using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
  void Update() {
    QuitGame();
  }

  void QuitGame() {
    if (Input.GetKey(KeyCode.Escape)) {
      Application.Quit();
    }
  }
}
