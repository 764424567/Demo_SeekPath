using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ray_Control : MonoBehaviour
{
    //控制那个摄像机发出射线
    public Camera m_Camera;
    //UI控制类
    public UI_Control m_UIControl;
    //点击鼠标显示的UI
    private GameObject m_UiPanel;
    //UI中的text
    public Text[] m_TextString;
    //设备的ID
    [HideInInspector]
    public int m_ID = 0;
    //控制点击到之后射线失效
    [HideInInspector]
    public bool m_IsFirst = true;

    // Use this for initialization
    void Start()
    {
        //获取ui对象
        m_UiPanel = m_UIControl.m_UIPanel;
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标点击
        if (Input.GetMouseButtonDown(0) && m_IsFirst)
        {
            //从鼠标点击的位置，从摄像机射出一条射线
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            //存储的是射线的各方面的值
            RaycastHit hit;
            //射线
            if (Physics.Raycast(ray,out hit))
            {
                //画一条线段，只能在scene视图中看到
                Debug.DrawLine(ray.origin, hit.point);
                //点击到的物体
                GameObject gameobj = hit.collider.gameObject;
                Debug.Log(gameobj.name);
                if (gameobj.tag == "shebei")
                {
                    //控制UI显示
                    m_UiPanel.transform.position = new Vector3(Input.mousePosition.x + 100, Input.mousePosition.y + 100, Input.mousePosition.z);
                    m_UiPanel.SetActive(true);
                    m_IsFirst = false;
                    //1号设备
                    if (gameobj.name == "Shebei01_Cube_Collider")
                    {
                        m_TextString[0].text = "A64654";
                        m_TextString[1].text = "xxxx";
                        m_ID = 1;
                    }
                    //2号设备
                    if (gameobj.name == "Shebei02_Cube_Collider")
                    {
                        m_TextString[0].text = "B84188";
                        m_TextString[1].text = "xxxx";
                        m_ID = 2;
                    }
                }
            }
        }
    }
}
