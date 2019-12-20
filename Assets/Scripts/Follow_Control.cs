using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Control : MonoBehaviour
{
    //目标点
    public Transform m_Target;
    //速度
    public float m_Speed;
    //时间间隔
    private float m_TimeDistance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_TimeDistance += Time.deltaTime * 10;
        if (m_TimeDistance > 1)
        {
            Follow_Move();
            m_TimeDistance = 0;
        }
    }

    void Follow_Move()
    {
        transform.position = Vector3.Lerp(transform.position, m_Target.position, m_Speed * Time.deltaTime);
    }
}
