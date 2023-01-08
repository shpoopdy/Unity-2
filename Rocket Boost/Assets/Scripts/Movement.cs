using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  /*
    PARAMETERS - for tuning, typically set in the editor
    CACHE - e.g. references for readability or speed
    STATE - private instance (member) variables
  */
  [SerializeField] float mainThrust = 100f;
  [SerializeField] float rotationThrust = 100f;
  [SerializeField] AudioClip mainEngine;

  [SerializeField] ParticleSystem leftEngineParticles;
  [SerializeField] ParticleSystem rightEngineParticles;

  Rigidbody rb;
  AudioSource audioSource;
  
  void Start() {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update() {
      ProcessThrust();
      ProcessRotation();
  }

  void ProcessThrust() {
    if (Input.GetKey(KeyCode.Space)) {
      StartThrusting();
    } else {
      StopThrusting();
    }
  }

  void StartThrusting() {
    rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    if (!audioSource.isPlaying) {
      audioSource.PlayOneShot(mainEngine);
    }
    if (!leftEngineParticles.isPlaying && !rightEngineParticles.isPlaying) {
      leftEngineParticles.Play();
      rightEngineParticles.Play();
    }
  }

  void StopThrusting() {
    audioSource.Stop();
    leftEngineParticles.Stop();
    rightEngineParticles.Stop();
  }

  void ProcessRotation() {
    if (Input.GetKey(KeyCode.D)) {
      ApplyRotation(-rotationThrust);
    }
    else if (Input.GetKey(KeyCode.A)) {
      ApplyRotation(rotationThrust);
    }
  }

  void ApplyRotation(float rotationThisFrame) {
    rb.freezeRotation = true; //Freezing rotation for manual rotation
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false; //Let physics take over after we are done.
  }
}
