using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
    public GameObject m_UIPanel;
    public Text m_Text;
    public GameObject m_TextObj;
    public Image m_ImageObstacle;
    public Sprite[] m_ImageObstacleSprite;

    // Use this for initialization
    void Start()
    {
        m_UIPanel.SetActive(false);
        m_TextObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
