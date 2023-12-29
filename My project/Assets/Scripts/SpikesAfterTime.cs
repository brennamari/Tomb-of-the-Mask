using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAfterTime : MonoBehaviour
{
   [SerializeField] float countDown;
   private List<Direction> dirOfTouch;
   [SerializeField] private LayerMask playerMask;

   public void Start()
   {
      dirOfTouch = new List<Direction>();
   }

   public void startCountDown()
   {
      if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 2f, playerMask)) dirOfTouch.Add(Direction.North);
      if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 2f, playerMask)) dirOfTouch.Add(Direction.South);
      if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 2f, playerMask)) dirOfTouch.Add(Direction.West);
      if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 2f, playerMask)) dirOfTouch.Add(Direction.East);
      StartCoroutine(KillPlayer(countDown));
   }
   
   IEnumerator KillPlayer(float waitTime)
   {
      yield return new WaitForSeconds(waitTime);
      Debug.Log(dirOfTouch.Count);
      foreach (Direction dir in dirOfTouch)
      {
         
         if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.6f, playerMask) && dir == Direction.North) Destroy(GameObject.Find("Player"));
         else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.6f, playerMask)  && dir == Direction.South) Destroy(GameObject.Find("Player"));
         else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.6f, playerMask)  && dir == Direction.West) Destroy(GameObject.Find("Player"));
         else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.6f, playerMask)  && dir == Direction.East) Destroy(GameObject.Find("Player")); 
      }
   }
}
