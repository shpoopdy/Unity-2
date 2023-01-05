using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      ProcessThrust();
      ProcessRotation();
  }

  void ProcessThrust() {
    if (Input.GetKey(KeyCode.Space)) {
      Debug.Log("Big Booty!");
    }
  }

  void ProcessRotation() {
    if (Input.GetKey(KeyCode.D)) {
      Debug.Log("Going RIGHT!");
    } else if (Input.GetKey(KeyCode.A)) {
      Debug.Log("Going LEFT!");
    }
  }
}
