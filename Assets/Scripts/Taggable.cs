using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour
{
   public bool isTagged = false;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Taggable"))
      {
         var taggable = other.gameObject.GetComponent<Taggable>();
         taggable.isTagged = false;
         isTagged = true;

      }
   }
}
