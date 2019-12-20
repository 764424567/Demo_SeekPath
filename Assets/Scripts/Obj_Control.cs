using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obj_Control : MonoBehaviour
{
    //地面搜索区域
    public GameObject m_FloorObj;
    //设备1障碍碰撞检测
    public GameObject[] m_BoxCollider1;
    //设备2障碍碰撞检测
    public GameObject[] m_BoxCollider2;
    //设备对象
    public GameObject[] m_Shebei;
    //最后下降的演示设备对象
    public GameObject[] m_ShebeiDown;
    //演示对象
    public GameObject[] m_TestObj;
    //演示对象
    public GameObject[] m_TestObjHash0;
    //演示对象
    public GameObject[] m_TestObjHash1;
    //演示对象的材质
    public Material[] m_TestObjMaterial;
    //自动寻路脚本
    public Nav_Control[] m_Nav;
    //AI寻路脚本
    public NavMeshAgent[] m_Agent;
    //障碍物
    public GameObject[] m_Obstacle;

    // Use this for initialization
    void Start()
    {
        //初始化
        m_FloorObj.SetActive(false);

        for (int i = 0; i < m_TestObj.Length; i++)
        {
            m_TestObj[i].SetActive(false);
        }

        for (int i = 0; i < m_BoxCollider1.Length; i++)
        {
            m_BoxCollider1[i].SetActive(false);
        }

        for (int i = 0; i < m_BoxCollider2.Length; i++)
        {
            m_BoxCollider2[i].SetActive(false);
        }

        for (int i = 0; i < m_Obstacle.Length; i++)
        {
            m_Obstacle[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
