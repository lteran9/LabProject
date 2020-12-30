using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private float speed = 750.0f;

   private Rigidbody enemyRb;
   private GameObject player;

   // Start is called before the first frame update
   void Start()
   {
      enemyRb = GetComponent<Rigidbody>();
      player = GameObject.Find("Player");
   }

   // Update is called once per frame
   void Update()
   {
      var lookDirection = (player.transform.position - transform.position).normalized;

      enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

      RotateTowards();
   }

   void RotateTowards()
   {
      // Determine which direction to rotate towards
      Vector3 targetDirection = player.transform.position - transform.position;

      // The step size is equal to speed times frame time.
      float singleStep = 1.0f * Time.deltaTime;

      // Rotate the forward vector towards the target direction by one step
      Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

      // Calculate a rotation a step closer to the target and applies rotation to this object
      transform.rotation = Quaternion.LookRotation(newDirection);
   }
}
