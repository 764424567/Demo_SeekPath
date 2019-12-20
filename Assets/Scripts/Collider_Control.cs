using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SheBei
{
    shebei1,
    shebei2
}
public class Collider_Control : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private Nav_Control m_Nav;
    public GameObject m_Player;
    //public GameObject m_PlayerCamera;
    public GameObject[] m_Target;
    public Obj_Control m_ObjControl;
    public SheBei shebei = SheBei.shebei1;
    public Camera_Control m_CameraControl;


    // Use this for initialization
    void Start()
    {
        m_Nav = m_ObjControl.m_Nav[0];
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //1号设备
        if (other.gameObject.name == "target1")
        {
            m_Nav = m_ObjControl.m_Nav[0];
            m_Agent = m_ObjControl.m_Agent[0];
            m_Agent.enabled = false;
            m_Nav.m_isFirst = false;
            m_Nav.enabled = false;
            //m_Player.transform.position = new Vector3(0f, 8f, 11.67f);
            //m_Player.transform.rotation = Quaternion.Euler(-90, 0, 0);
            //m_Player.transform.localScale = new Vector3(1, 1, 1);
            //m_PlayerCamera.transform.localPosition = new Vector3(-4.426f, -3.03f, 4.9f);
            //m_PlayerCamera.transform.localEulerAngles = new Vector3(-34f, 135f, 60f);
            m_ObjControl.m_BoxCollider1[0].SetActive(false);
            m_ObjControl.m_BoxCollider1[1].SetActive(false);
            m_ObjControl.m_Shebei[0].SetActive(false);
            m_CameraControl.m_Camera[4].SetActive(true);
            //0.3f,19.8f,4.3f
            m_CameraControl.m_Camera[4].transform.position = new Vector3(1.5f, 23f, 8.6f);
            m_CameraControl.m_Camera[4].transform.localEulerAngles = new Vector3(74f, 0, 0);
            m_ObjControl.m_ShebeiDown[0].SetActive(true);
            m_ObjControl.m_ShebeiDown[0].SetActive(true);  
        }
        //2号设备
        if (other.gameObject.name == "target")
        {
            m_Nav = m_ObjControl.m_Nav[1];
            m_Agent = m_ObjControl.m_Agent[1];
            m_Agent.enabled = false;
            m_Nav.m_isFirst = false;
            m_Nav.enabled = false;
            //m_Player.transform.position = new Vector3(5.601f, 11.07f, 12.236f);
            //m_Player.transform.rotation = Quaternion.Euler(-90, 0, 0);
            //m_PlayerCamera.transform.localPosition = new Vector3(3f, 1f, 2f);
            //m_PlayerCamera.transform.localRotation = Quaternion.Euler(21f, -120f, -100f);
            m_ObjControl.m_BoxCollider2[0].SetActive(false);
            m_ObjControl.m_BoxCollider2[1].SetActive(false);
            m_ObjControl.m_Shebei[1].SetActive(false);
            m_CameraControl.m_Camera[4].SetActive(true);
            m_CameraControl.m_Camera[4].transform.position = new Vector3(2.335106f, 19.57973f, 13.63064f);
            m_CameraControl.m_Camera[4].transform.localEulerAngles = new Vector3(36.6f, 96.6f, 0);
            m_ObjControl.m_ShebeiDown[1].SetActive(true);
            m_ObjControl.m_ShebeiDown[1].SetActive(true);
        }
        //1号设备
        if (shebei == SheBei.shebei1)
        {
            switch (other.gameObject.name)
            {
                case "target1-1":
                    m_Nav.m_Target = m_Target[0];
                    break;
                case "target1-1 (1)":
                    m_Nav.m_Target = m_Target[1];
                    break;
                case "target1-1 (2)":
                    m_Nav.m_Target = m_Target[2];
                    break;
                case "target1-1 (3)":
                    m_Nav.m_Target = m_Target[3];
                    break;
                default:
                    break;
            }
        }
    }
}
