﻿
   using System;
   using UnityEngine;
   public class EnemyMovement : MonoBehaviour
   {
       
       int currentWaypointIndex = 0;
       [SerializeField] private Transform[] waypoints;
       [SerializeField] private float moveSpeed = 20f;
       [SerializeField] private float rotationSpeed = 5f;

       private void FixedUpdate()
       {
              if (waypoints.Length == 0) return;
              if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
              {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                     currentWaypointIndex = 0;
                }
              }
              transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed*Time.fixedDeltaTime);
              transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation(Vector3.forward, waypoints[currentWaypointIndex].position - transform.position),rotationSpeed * Time.fixedDeltaTime);
              
       }
   }
