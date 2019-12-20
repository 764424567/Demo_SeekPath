using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_Control : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    public GameObject m_Target;
    private LineRenderer m_LineRender;
    [HideInInspector]
    public bool m_isFirst = true;
    // Use this for initialization
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_LineRender = GetComponent<LineRenderer>();
        //m_Agent.SetDestination(m_Target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isFirst)
        {
            //设置目标点
            m_Agent.SetDestination(m_Target.transform.position);
            //储存路径
            Vector3[] path = m_Agent.path.corners;
            //设置顶点的数量
            m_LineRender.positionCount = path.Length;
            //设置线段
            for (int i = 0; i < path.Length; i++)
            {
                m_LineRender.SetPositions(path);
            }
        }
    }
}
