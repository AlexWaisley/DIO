using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SlideManager : MonoBehaviour
{
    [SerializeField] public UnityEvent incorrectClicked;
    private List<Slide> m_Slides;
    private int SlideIndex
    {
        get { return m_Slides.FindIndex(x => x.gameObject.activeSelf); }
        set
        {
            foreach (var g in m_Slides)
                g.gameObject.SetActive(false);
            m_Slides[value].gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        var t= GetComponent<Transform>();
        m_Slides = new List<Slide>();
        for (var i = 0; i < t.childCount; i++) 
            m_Slides.Add(t.GetChild(i).GetComponent<Slide>());
        foreach (var g in m_Slides)
        {
            g.missAns.AddListener(incorrectClicked.Invoke);
            g.rightAns.AddListener(RightCl);
        }
        SlideIndex = 0;
    }

    private void RightCl()
    {
        Debug.Log(SlideIndex);
        SlideIndex++;
    }

    public void HideAll()
    {
        foreach (var g in m_Slides) 
            g.gameObject.SetActive(false);
    }
}