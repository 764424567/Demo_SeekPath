using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
    //进度条对象
    public GameObject m_Slider;
    //进度条控制脚本
    public Slider_Control m_SliderControl;
    //摄像机控制脚本
    public Camera_Control m_CameraControl;
    //射线控制脚本
    public Ray_Control m_RayControl;


    // Use this for initialization
    void Start()
    {
        //设置进度条不可见
        m_Slider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Button_OnClick_Restart();
        }
    }

    //控制显示进度条
    public void Button_OnClick_UIShow()
    {
        //显示进度条
        m_Slider.SetActive(true);
        //执行代码
        m_SliderControl.m_isFrist = true;
    }

    //控制摄像机切换
    public void Button_OnClick_CameraControl()
    {
        //1号设备
        if (m_RayControl.m_ID == 1)
        {
            //主摄像头隐藏，1号设备摄像头显示
            m_CameraControl.m_Camera[0].SetActive(false);
            m_CameraControl.m_Camera[1].SetActive(true);
        }
        //2号设备
        if (m_RayControl.m_ID == 2)
        {
            // 主摄像头隐藏，2号设备摄像头显示
            m_CameraControl.m_Camera[0].SetActive(false);
            m_CameraControl.m_Camera[2].SetActive(true);
        }
    }

    //重新开始
    public void Button_OnClick_Restart()
    {
        SceneManager.LoadScene(0);
    }
}
