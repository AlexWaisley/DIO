using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatleManager : MonoBehaviour
{
   [SerializeField] public BatleTimer timer;
   [SerializeField] public SlideManager sManager;
   [SerializeField] public int secsToRemoveInc;

   private void Start()
   {
      sManager.incorrectClicked.AddListener(() => timer.RemoveSecs(secsToRemoveInc));
   }
}
