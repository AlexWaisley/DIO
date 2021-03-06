using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
  internal bool OnGround { get;  set; }
  internal BlockMove MoveBlockOn { get;  set; }
  private void OnTriggerExit2D(Collider2D other)
  {
    if(!other.CompareTag("ground")) return;
    MoveBlockOn = null;
    OnGround = false;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(!other.CompareTag("ground")) return;
    MoveBlockOn =  other.GetComponentInParent<BlockMove>();
    OnGround = true;
  }
}
