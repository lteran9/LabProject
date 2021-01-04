﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private bool isOnGround = true;
   private float speed = 500.0f;
   private float jumpForce = 5.0f;
   private float areaBounds = 20.0f;

   private Taggable tagg;
   private Rigidbody playerRb;
   private GameObject focalPoint;


   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("Focal Point");
      tagg = GetComponent<Taggable>();
      tagg.isTagged = true;
   }

   // Update is called once per frame
   void Update()
   {
      Player_Move();
      Player_Jump();
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
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
   }

   void Player_Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         isOnGround = false;
      }
   }
}
