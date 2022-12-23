using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private SkinManager skinManager;
  private float smoothTime = 0.1f;
  private float playerSPeed = 10f;
  private Vector3 velocity = Vector3.zero;
  private Vector3 direction;
  private Renderer playerBody;
  private const string SelectedSkin = "SelectedSkin";

  void Start()
  {
    playerBody = GetComponent<Renderer>();
    Debug.Log(" skinManager.GetSelectedSkin().texture = " + skinManager.GetSelectedSkin().texture);
    playerBody.material.mainTexture = skinManager.GetSelectedSkin().texture;
  }

  void Update()
  {
      playerBody.material.mainTexture = skinManager.GetSelectedSkin().texture;
  }
}
