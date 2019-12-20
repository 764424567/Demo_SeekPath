using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


enum TimeControl
{
    Default,         //默认
    RegionSearch,    //区域搜素
    GetPath,         //计算路径
    ObstaclesAvoid,  //障碍躲避
    PathFinding,     //自动寻路
    Compute          //计算过程
}

public class Button_Control2 : MonoBehaviour
{
    //获取到UI控制对象
    public UI_Control m_UIControl;
    //UI对象
    private GameObject m_UIPanel;
    //text对象
    private Text m_Text;
    //时间间隔对象
    private float m_TimeDis = 0;
    private float m_TimeAdd = 0;
    //文字播放速度
    private float m_Speed = 1;
    //流程控制对象
    TimeControl m_TimeControl;
    //对象控制脚本
    public Obj_Control m_ObjControl;
    private GameObject m_FloorObj;
    //获取到寻路脚本
    private Nav_Control m_Nav;
    //获取到自动寻路脚本
    private NavMeshAgent m_NavMeshAgent;
    //获取到射线脚本
    public Ray_Control m_RayControl;
    //执行一次
    private bool m_isFrist = true;
    //摄像机控制脚本
    public Camera_Control m_CameraControl;
    //障碍物设置按钮
    private bool m_IsButtonObstacle = true;

    private void Start()
    {
        //初始化
        m_TimeControl = TimeControl.Default;
        //获取到ui对象
        m_UIPanel = m_UIControl.m_UIPanel;
        m_Text = m_UIControl.m_Text;
        //获取到地面搜索
        m_FloorObj = m_ObjControl.m_FloorObj;
    }

    private void Update()
    {
        //重新开始
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Button_OnClick_Restart();
        }


        if (m_isFrist)
        {
            if (m_RayControl.m_ID == 1)
            {
                //获取到寻路
                m_Nav = m_ObjControl.m_Nav[0];
                m_NavMeshAgent = m_ObjControl.m_Agent[0];
                m_Nav.enabled = false;
                m_NavMeshAgent.speed = 0;
                m_isFrist = false;
            }
            if (m_RayControl.m_ID == 2)
            {
                //获取到寻路
                m_Nav = m_ObjControl.m_Nav[1];
                m_NavMeshAgent = m_ObjControl.m_Agent[1];
                m_Nav.enabled = false;
                m_NavMeshAgent.speed = 0;
                m_isFrist = false;
            }
        }

        //搜索路径
        if (m_TimeControl == TimeControl.RegionSearch)
        {
            m_UIControl.m_TextObj.SetActive(true);

            m_TimeDis += Time.deltaTime * m_Speed;
            m_TimeAdd += Time.deltaTime * m_Speed;
            if (m_TimeDis > 2)
            {
                m_Text.text = "正在建立搜索区域" + ".";
            }
            if (m_TimeDis > 3)
            {
                m_Text.text = "正在建立搜索区域" + "..";
            }
            if (m_TimeDis > 4)
            {
                m_Text.text = "正在建立搜索区域" + "...";
            }
            if (m_TimeDis > 5)
            {
                m_Text.text = "正在建立搜索区域" + "....";
                m_TimeDis = 0;
            }
            if (m_TimeAdd > 7)
            {
                m_Text.text = "<color=green>建立搜索区域完毕</color>";
                m_FloorObj.SetActive(true);
            }
            if (m_TimeAdd > 10)
            {
                m_TimeControl = TimeControl.GetPath;
                m_TimeAdd = 0;
            }
        }
        //计算路径
        if (m_TimeControl == TimeControl.GetPath)
        {
            m_TimeAdd += Time.deltaTime * m_Speed;
            m_TimeDis += Time.deltaTime * m_Speed;

            if (m_TimeDis > 0)
            {
                m_Text.text = "正在计算路线" + ".";
            }
            if (m_TimeDis > 3)
            {
                m_Text.text = "正在计算路线" + ".." + "\n" + "正在计算进入角度.." + "\n" + "<color=green>绿色</color>为可进入，<color=red>红色</color>为不可进入..";
            }
            if (m_TimeDis > 4)
            {
                m_Text.text = "正在计算路线" + "..." + "\n" + "正在计算进入角度..." + "\n" + "<color=green>绿色</color>为可进入，<color=red>红色</color>为不可进入...";
            }
            if (m_TimeDis > 5)
            {
                m_Text.text = "正在计算路线" + "...." + "\n" + "正在计算进入角度...." + "\n" + "<color=green>绿色</color>为可进入，<color=red>红色</color>为不可进入....";
                m_TimeDis = 3;
            }
            //设备1
            if (m_RayControl.m_ID == 1)
            {
                //判断什么时间到达什么门
                if (m_TimeAdd > 2)
                {
                    //启用3号摄像头
                    m_CameraControl.Button_OnClick_Camera03_On();
                    //1号门  第一个角度 
                    Camera_Control(1, 1);
                }
                if (m_TimeAdd > 4)
                {
                    //第二个角度 
                    Camera_Control(1, 2);
                }
                if (m_TimeAdd > 6)
                {
                    //第三个角度 
                    Camera_Control(1, 3);
                }
                if (m_TimeAdd > 8)
                {
                    //第四个角度 
                    Camera_Control(1, 4);
                }
                if (m_TimeAdd > 10)
                {
                    //第五个角度 
                    Camera_Control(1, 5);
                }
                //2号门
                if (m_TimeAdd > 12)
                {
                    Camera_Control(2, 1);
                }
                if (m_TimeAdd > 14)
                {
                    Camera_Control(2, 2);
                }
                if (m_TimeAdd > 16)
                {
                    Camera_Control(2, 3);
                }
                if (m_TimeAdd > 18)
                {
                    Camera_Control(2, 4);
                }
                //3号门
                if (m_TimeAdd > 20)
                {
                    Camera_Control(3, 1);
                }
                if (m_TimeAdd > 22)
                {
                    Camera_Control(3, 2);
                }
                if (m_TimeAdd > 24)
                {
                    Camera_Control(3, 3);
                }
                if (m_TimeAdd > 26)
                {
                    Camera_Control(3, 4);
                }
                if (m_TimeAdd > 28)
                {
                    Camera_Control(3, 5);
                }
                //演示完毕
                if (m_TimeAdd > 30)
                {
                    m_Text.text = "<color=green>计算完毕</color>";
                    //2号设备
                    m_ObjControl.m_TestObj[0].SetActive(false);
                    m_CameraControl.Button_OnClick_MainCamera();
                    m_FloorObj.SetActive(false);
                    m_TimeAdd = 0;
                    
                    m_NavMeshAgent.speed = 0;
                    m_TimeControl = TimeControl.ObstaclesAvoid;
                }
            }
            //设备2
            if (m_RayControl.m_ID == 2)
            {
                //判断什么时间到达什么门
                if (m_TimeAdd > 2)
                {
                    //启用3号摄像头
                    m_CameraControl.Button_OnClick_Camera03_On();
                    //1号门  第一个角度 
                    Camera_Control(1, 1);
                }
                if (m_TimeAdd > 4)
                {
                    //第二个角度 
                    Camera_Control(1, 2);
                }
                if (m_TimeAdd > 6)
                {
                    //第三个角度 
                    Camera_Control(1, 3);
                }
                if (m_TimeAdd > 8)
                {
                    //第四个角度 
                    Camera_Control(1, 4);
                }
                if (m_TimeAdd > 10)
                {
                    //第五个角度 
                    Camera_Control(1, 5);
                }
                //2号门
                if (m_TimeAdd > 12)
                {
                    Camera_Control(2, 1);
                }
                if (m_TimeAdd > 14)
                {
                    Camera_Control(2, 2);
                }
                if (m_TimeAdd > 16)
                {
                    Camera_Control(2, 3);
                }
                if (m_TimeAdd > 18)
                {
                    Camera_Control(2, 4);
                }
                if (m_TimeAdd > 20)
                {
                    Camera_Control(2, 5);
                }
                //演示完毕
                if (m_TimeAdd > 22)
                {
                    m_Text.text = "<color=green>计算完毕</color>";
                    //2号设备
                    m_ObjControl.m_TestObj[1].SetActive(false);
                    m_CameraControl.Button_OnClick_MainCamera();
                    m_FloorObj.SetActive(false);
                    m_TimeAdd = 0;
                    m_NavMeshAgent.speed = 0;
                    m_TimeControl = TimeControl.ObstaclesAvoid;
                }
            }
        }
        //障碍躲避
        if (m_TimeControl == TimeControl.ObstaclesAvoid)
        {
            m_TimeAdd += Time.deltaTime * m_Speed;
            m_TimeDis += Time.deltaTime * m_Speed;
            m_CameraControl.Button_OnClick_Camera03_On();
            if (m_RayControl.m_ID == 1)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(50.11f, 4.45f, -14.96477f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(42.32f, -94.331f, 0);
            }
            if (m_RayControl.m_ID == 2)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(-20.32f, 8.82f, -47f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(47f, 0, 0);
            }
            if (m_TimeDis > 2)
            {
                m_Text.text = "正在创建障碍躲避检测光圈" + ".";
            }
            if (m_TimeDis > 3)
            {
                m_Text.text = "正在创建障碍躲避检测光圈" + "..";
            }
            if (m_TimeDis > 4)
            {
                m_Text.text = "正在创建障碍躲避检测光圈" + "...";
            }
            if (m_TimeDis > 5)
            {
                m_Text.text = "正在创建障碍躲避检测光圈" + "....";
                m_TimeDis = 0;
            }
            if (m_TimeAdd > 7)
            {
                m_Text.text = "<color=green>创建完毕</color>";
                if (m_RayControl.m_ID == 1)
                {
                    for (int i = 0; i < m_ObjControl.m_BoxCollider1.Length; i++)
                    {
                        m_ObjControl.m_BoxCollider1[i].SetActive(true);
                    }
                }
                if (m_RayControl.m_ID == 2)
                {
                    for (int i = 0; i < m_ObjControl.m_BoxCollider2.Length; i++)
                    {
                        m_ObjControl.m_BoxCollider2[i].SetActive(true);
                    }
                }
            }
            if (m_TimeAdd > 10)
            {
                m_TimeAdd = 0;
                m_TimeControl = TimeControl.PathFinding;
                m_CameraControl.Button_OnClick_MainCamera();
            }
        }
        //自动寻路
        if (m_TimeControl == TimeControl.PathFinding)
        {
            m_TimeAdd += Time.deltaTime * m_Speed;
            if (m_TimeAdd > 3)
            {
                m_Nav.enabled = true;
                m_Text.text = "正在寻路...";
                m_NavMeshAgent.speed = 3.5f;
            }
            if (m_TimeAdd > 4)
            {
                if (m_RayControl.m_ID == 1)
                {
                    m_CameraControl.Button_OnClick_Camera01_On();
                }
                if (m_RayControl.m_ID == 2)
                {
                    m_CameraControl.Button_OnClick_Camera02_On();
                }
                m_Text.text = "";
            }
        }
    }

    //参数i 表示到达那个门  参数j 表示进行到什么步骤
    public void Camera_Control(int i, int j)
    {
        //1号设备
        if (m_RayControl.m_ID == 1)
        {
            //判断是那个门
            if (i == 1)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(36.1f, 17.52f, -15.29f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(6.224f, -90f, 0);
                m_ObjControl.m_TestObj[0].SetActive(true);
                m_ObjControl.m_TestObj[0].transform.position = new Vector3(30.87f, 16.5f, -15.304f);
                switch (j)
                {
                    case 1:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-75, -110, 90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 2:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-145, -169, 0);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 3:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(0, -90, -90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    case 4:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-200, -156, 0);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 5:
                        //0,-90,-90
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-156, -157, 0);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    default:
                        break;
                }
            }
            //第二个门
            if (i == 2)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(14f, 18f, -15.331f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(17, -90, 0);
                m_ObjControl.m_TestObj[0].SetActive(true);
                m_ObjControl.m_TestObj[0].transform.position = new Vector3(8.93f, 16.5f, -15.304f);
                switch (j)
                {
                    case 1:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-47, -78, -78);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 2:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(0, 45, -78);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 3:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(10, -78, 10);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 4:
                        //0, -90, -90
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(0, -90, -90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    default:
                        break;
                }
            }
            //第三个门
            if (i == 3)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(1.37f, 17.176f, -1.894f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(0, 0, 0);
                m_ObjControl.m_TestObj[0].SetActive(true);
                m_ObjControl.m_TestObj[0].transform.position = new Vector3(1.49f, 16.50405f, 3.5f);
                switch (j)
                {
                    case 1:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(0, -123, -123);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 2:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(0, 0, -90 );
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    case 3:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-49, -110, -89);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 4:
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(45, -10, -89);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 5:
                        //0, 0, -90
                        m_ObjControl.m_TestObj[0].transform.localEulerAngles = new Vector3(-20, -150, -10);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash0.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash0[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        //2号设备
        if (m_RayControl.m_ID == 2)
        {
            //判断是那个门
            if (i == 1)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(-17.33f, 2.39f, -24f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(16f, 0, 0);
                m_ObjControl.m_TestObj[1].SetActive(true);
                m_ObjControl.m_TestObj[1].transform.position = new Vector3(-17.34f, 1.74f, -17.83f);
                switch (j)
                {
                    case 1:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(0, -40, 90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    case 2:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(20, -88, 50);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 3:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(78, -78, 210);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 4:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(154, -47, 75);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    case 5:
                        //0, 0, 90
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(0, 0, 90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    default:
                        break;
                }
            }
            //第二个门
            if (i == 2)
            {
                m_CameraControl.m_Camera[3].transform.position = new Vector3(1f, 18f, -3f);
                m_CameraControl.m_Camera[3].transform.localEulerAngles = new Vector3(0, 0, 0);
                m_ObjControl.m_TestObj[1].SetActive(true);
                m_ObjControl.m_TestObj[1].transform.position = new Vector3(1.19f, 16.39f, 3.43f);
                switch (j)
                {
                    case 1:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(0, -110, 20);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 2:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(80, -154, 50);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 3:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(10, -55, 20);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 4:
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(87, -78, 90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[2];
                        }
                        break;
                    case 5:
                        //0, 0, 90
                        m_ObjControl.m_TestObj[1].transform.localEulerAngles = new Vector3(0, 0, 90);
                        for (int x = 0; x < m_ObjControl.m_TestObjHash1.Length; x++)
                        {
                            m_ObjControl.m_TestObjHash1[x].GetComponent<MeshRenderer>().material = m_ObjControl.m_TestObjMaterial[1];
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void Button_OnClick_True()
    {
        m_UIPanel.SetActive(false);
        m_Text.enabled = true;
        m_TimeControl = TimeControl.RegionSearch;
        m_Text.text = "开始搜索...";
    }

    public void Button_OnClick_False()
    {
        m_UIPanel.SetActive(false);
        //点击关闭 射线脚本又可以用了
        m_RayControl.m_IsFirst = true;
    }

    //重新开始
    public void Button_OnClick_Restart()
    {
        SceneManager.LoadScene(0);
    }

    //设置障碍物
    public void Button_OnClick_ObstacleControl()
    {
        if (m_IsButtonObstacle)
        {
            m_UIControl.m_ImageObstacle.sprite = m_UIControl.m_ImageObstacleSprite[0];
            for (int i = 0; i < m_ObjControl.m_Obstacle.Length; i++)
            {
                m_ObjControl.m_Obstacle[i].SetActive(true);
            }
            m_IsButtonObstacle = false;
        }
        else
        {
            m_UIControl.m_ImageObstacle.sprite = m_UIControl.m_ImageObstacleSprite[1];
            for (int i = 0; i < m_ObjControl.m_Obstacle.Length; i++)
            {
                m_ObjControl.m_Obstacle[i].SetActive(false);
            }
            m_IsButtonObstacle = true;
        }
    }

    //退出程序
    public void Button_OnClick_Quit()
    {
        Application.Quit();
    }
}
