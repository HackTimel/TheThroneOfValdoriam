using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCameraController : MonoBehaviour
{
  public CinemachineFreeLook virtualCamera;
  public float rotationY;

  public void Update()
  {
    var state = virtualCamera.State;
    var rotation = state.FinalOrientation;
    var euleur = rotation.eulerAngles;
    rotationY = euleur.y;
    var roundedRotation = Mathf.Round(rotationY);
  } 
  public Quaternion flatRotation => Quaternion.Euler(0, rotationY, 0);
}
