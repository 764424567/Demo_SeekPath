using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//摄像机控制类
public class Camera_Control : MonoBehaviour
{
    //控制场景中所有的摄像机对象
    public GameObject[] m_Camera;
    

    // Use this for initialization
    void Start()
    {
        //设置主摄像机可见
        for (int i = 0; i < m_Camera.Length; i++)
        {
            m_Camera[i].SetActive(false);
        }
        m_Camera[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_OnClick_MainCamera()
    {
        m_Camera[0].SetActive(true);
        m_Camera[3].SetActive(false);
    }

    public void Button_OnClick_Camera01_On()
    {
        m_Camera[0].SetActive(false);
        m_Camera[3].SetActive(false);
        m_Camera[1].SetActive(true);
    }

    public void Button_OnClick_Camera02_On()
    {
        m_Camera[0].SetActive(false);
        m_Camera[3].SetActive(false);
        m_Camera[2].SetActive(true);
    }

    public void Button_OnClick_Camera03_On()
    {
        m_Camera[0].SetActive(false);
        m_Camera[3].SetActive(true);
    }

    public void DownCameraControl01()
    {
        m_Camera[4].transform.position = new Vector3(-4.3f, 11.645f, 14.8f);
        m_Camera[4].transform.localEulerAngles = new Vector3(23.566f, 137.556f, 1.113f);
    }

    public void DownCameraControl02()
    {
        m_Camera[4].transform.position = new Vector3(8f, 14f, 11f);
        m_Camera[4].transform.localEulerAngles = new Vector3(45f, -75f, 0);
    }
}
