using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Control : MonoBehaviour
{
    public GameObject[] m_ArrowUp;
    public GameObject[] m_ArrowDown;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < m_ArrowUp.Length; i++)
        {
            m_ArrowUp[i].SetActive(false);
        }
        for (int i = 0; i < m_ArrowDown.Length; i++)
        {
            m_ArrowDown[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void shebei01_Arrow()
    {
        m_ArrowUp[0].SetActive(true);
        m_ArrowDown[0].SetActive(true);
    }

    public void shebei02_arrow()
    {
        m_ArrowUp[1].SetActive(true);
        m_ArrowDown[1].SetActive(true);
    }
}
