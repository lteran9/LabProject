using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
   private float rotationSpeed = 200;

   private GameObject player;

   // Start is called before the first frame update
   void Start()
   {
      player = GameObject.Find("Player");
   }

   // Update is called once per frame
   void Update()
   {
      float horizontalInput = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

      transform.position = player.transform.position; // Move focal point with player
   }
}
