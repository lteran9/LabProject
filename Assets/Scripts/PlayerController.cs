using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private bool isOnGround = true;
   private float speed = 125.0f;
   private float jumpForce = 500.0f;
   private Rigidbody playerRb;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(Vector3.forward * speed * verticalInput);
      playerRb.AddForce(Vector3.right * speed * horizontalInput);

      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         isOnGround = false;
      }
   }

   void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
      }
   }
}
