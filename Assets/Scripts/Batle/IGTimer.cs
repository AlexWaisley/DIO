using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class IgTimer : MonoBehaviour
{
    [SerializeField] private int totalSeconds;
    [SerializeField] public UnityEvent timeEnds;
    private DateTime m_StartTime;
    private Text m_Text;
    private int m_RemovedSecs;
    private bool m_Stopped;
    private void Start()
    {
        ResetTimer();
        m_Text = GetComponentInChildren<Text>();
    }

    private void ResetTimer()
    {
        m_StartTime = DateTime.Now;
        m_RemovedSecs = 0;
        m_Stopped = false;
    }
    public void RemoveSecs(int s) => m_RemovedSecs += s;

    private TimeSpan TimeLeft
    {
        get
        {
            var s = m_StartTime.Subtract(DateTime.Now);
            var ts = TimeSpan.FromSeconds(totalSeconds);
            var tr = TimeSpan.FromSeconds(-m_RemovedSecs);
            return ts.Add(s).Add(tr);
        }
    }
    
    
    private void CheckTimer()
    {
        var prc = (float)(TimeLeft.TotalSeconds / totalSeconds);
        if (!(prc <= 0)) return;
        timeEnds.Invoke();
        m_Stopped = true;
    }
    
    private void UpdateTimer()
    {
        var sx = TimeLeft;
        var prc = (float)(sx.TotalSeconds / totalSeconds);
        m_Text.color = Color.HSVToRGB( prc/3, 1, 1);
        m_Text.text = sx.ToString("mm':'ss':'ff");
    }
    private void Update()
    {
        if (m_Stopped) return;
        UpdateTimer();
        CheckTimer();

    }
}
