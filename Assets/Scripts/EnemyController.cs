using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public float speed = 350.0f;

   private Taggable tagg;
   private Rigidbody enemyRb;
   private List<GameObject> players;

   // Start is called before the first frame update
   void Start()
   {
      enemyRb = GetComponent<Rigidbody>();
      players = GameObject.FindGameObjectsWithTag("Taggable").ToList();
      tagg = GetComponent<Taggable>();
   }

   // Update is called once per frame
   void Update()
   {
      if (tagg.isTagged == false)
      {
         var taggedPlayer = GetTaggedPlayer();
         if (taggedPlayer != null)
         {
            RotateTowards(taggedPlayer);
         }
      }
      else
      {
         
      }

   }

   void RotateTowards(GameObject player)
   {
      // Get direction to look 
      var lookDirection = (player.transform.position - transform.position).normalized;

      // Move towards direction
      enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

      // Determine which direction to rotate towards
      Vector3 targetDirection = player.transform.position - transform.position;

      // The step size is equal to speed times frame time.
      float singleStep = 1.0f * Time.deltaTime;

      // Rotate the forward vector towards the target direction by one step
      Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

      // Calculate a rotation a step closer to the target and applies rotation to this object
      transform.rotation = Quaternion.LookRotation(newDirection);
   }

   void RotateAway(GameObject player)
   {
      // Get direction to look 
      var lookDirection = (transform.position - player.transform.position).normalized;

      // Move towards direction
      enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

      // Determine which direction to rotate towards
      Vector3 targetDirection = player.transform.position - transform.position;

      // The step size is equal to speed times frame time.
      float singleStep = 1.0f * Time.deltaTime;

      // Rotate the forward vector towards the target direction by one step
      Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

      // Calculate a rotation a step closer to the target and applies rotation to this object
      transform.rotation = Quaternion.LookRotation(newDirection);
   }

   GameObject GetTaggedPlayer()
   {
      if (players?.Count > 0)
      {
         foreach (var player in players)
         {
            var taggable = player.GetComponent<Taggable>();
            if (taggable.isTagged)
            {
               return player;
            }
         }
      }

      return null;
   }
}
