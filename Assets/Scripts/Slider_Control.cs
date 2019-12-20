using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Control : MonoBehaviour
{
    //进度条
    public Slider m_Slider;
    //图片
    public Image m_Image;
    //进度条速度间隔
    private float m_RotateTime;
    //进度条显示文本
    public Text m_SliderNumTest;
    //进度条推进速度
    public float m_SliderSpeed = 3;
    //控制代码运行
    [HideInInspector]
    public bool m_isFrist = false;
    //两条线段
    public GameObject[] m_LineRender;
    //射线控制脚本
    public Ray_Control m_RayControl;
    //控制按钮点击的脚本
    public Button_Control m_ButtonControl2;
    //控制设备运输的button按钮
    public GameObject[] m_UiTransportationFacility;
    //UI管理对象
    public UI_Control m_UIControl;
    //UI对象
    private GameObject m_UIPanel;

    // Use this for initialization
    void Start()
    {
        m_UIPanel = m_UIControl.m_UIPanel;
        //控制线段跟控制设备运输的按钮都不可见
        for (int i = 0; i < m_LineRender.Length; i++)
        {
            m_LineRender[i].SetActive(false);
        }
        for (int i = 0; i < m_UiTransportationFacility.Length; i++)
        {
            m_UiTransportationFacility[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //控制代码运行
        if (m_isFrist)
        {
            //设置进度条的值
            m_Slider.value = m_RotateTime / m_SliderSpeed;
            m_RotateTime += Time.deltaTime;
            //设置进度条数值
            int num = (int)(m_Slider.value * 100);
            m_SliderNumTest.text = num.ToString() + "%";
            //当进度条的值不满的时候，设置为100
            if (m_Slider.value >= 0.997f)
            {
                m_SliderNumTest.text = "100%";
                //1号设备
                if (m_RayControl.m_ID == 1)
                {
                    //1号线段 1号控制运输的脚本
                    m_LineRender[0].SetActive(true);
                    m_UiTransportationFacility[0].SetActive(true);    
                }
                //2号设备
                if (m_RayControl.m_ID == 2)
                {
                    //2号线段 2号控制运输的脚本
                    m_LineRender[1].SetActive(true);
                    m_UiTransportationFacility[1].SetActive(true);    
                }
                //射线显示的UIpanel隐藏
                m_UIPanel.SetActive(false);
                //进度条隐藏
                m_ButtonControl2.m_Slider.SetActive(false);
                //射线控制脚本不可用
                m_RayControl.enabled = false;
                //重新开始的按钮
                m_UiTransportationFacility[2].SetActive(true);
            }
        }
    }

    //图片跟随进度条的值变化旋转
    public void ImageRotate_Control(float i)
    {
        m_Image.transform.eulerAngles = new Vector3(0, 0, i * 360);
    }
}
