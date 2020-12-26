﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private bool isOnGround = true;
   private float speed = 125.0f;
   private float jumpForce = 150.0f;
   private float areaBounds = 20.0f;

   private Rigidbody playerRb;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {
      Player_Move();
      Player_Jump();
      Player_Bounds();
   }

   void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
      }
   }

   void Player_Move()
   {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(Vector3.forward * speed * verticalInput);
      playerRb.AddForce(Vector3.right * speed * horizontalInput);
   }

   void Player_Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         isOnGround = false;
      }
   }

   void Player_Bounds()
   {
      if (transform.position.x > areaBounds)
      {
         transform.position = new Vector3(areaBounds, transform.position.y, transform.position.z);
      }

      if (transform.position.x < -areaBounds)
      {
         transform.position = new Vector3(-areaBounds, transform.position.y, transform.position.z);
      }

      if (transform.position.z > areaBounds)
      {
         transform.position = new Vector3(transform.position.x, transform.position.y, areaBounds);
      }

      if (transform.position.z < -areaBounds)
      {
         transform.position = new Vector3(transform.position.x, transform.position.y, -areaBounds);
      }
   }
}
