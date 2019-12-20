using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontAni_Control : MonoBehaviour
{
    public float m_Speed;
    private float m_TimeDis;
    public Text m_Textwb;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_TimeDis += Time.deltaTime * m_Speed;
        if (m_TimeDis > 1)
        {
            m_Textwb.text = "正在寻路中" + ".";
        }
        if (m_TimeDis > 2)
        {
            m_Textwb.text = "正在寻路中" + "..";
        }
        if (m_TimeDis > 3)
        {
            m_Textwb.text = "正在寻路中" + "...";
            m_TimeDis = 0;
        }
    }
}
