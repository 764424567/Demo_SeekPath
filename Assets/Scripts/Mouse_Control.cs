using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Control : MonoBehaviour
{
    //x轴移动速度
    public float xRoatationSpeed = 250.0f;
    //y轴移动速度
    public float yRoatationSpeed = 120.0f;

    //移动速度
    public float moveSpeed = 800f;

    //y轴可以移动的最大值和最小值设置
    public float yRoatationMinLimit = -90f;
    public float yRoatationMaxLimit = 90f;

    //缩放速度
    public float ScaleSpeed = 300;

    //键盘移动的速度
    public float KeyboardMoveSpeed = 10;
    //默认键盘移动速度
    public float DefaultKeyboardMoveSpeed = 10;
    //键盘输入移动加速度
    public float KeyboardMoveAcceleratedSpeed = 3;

    //最大移动间隔
    public float MaxMoveDistance = 5000f;

    //参数重构
    private KeyCode _forwardKey = KeyCode.W;

    public KeyCode ForwardKey
    {
        get { return _forwardKey; }
        set { _forwardKey = value; }
    }

    private KeyCode _backKey = KeyCode.S;

    public KeyCode BackKey
    {
        get { return _backKey; }
        set { _backKey = value; }
    }

    private KeyCode _leftKey = KeyCode.A;

    public KeyCode LeftKey
    {
        get { return _leftKey; }
        set { _leftKey = value; }
    }

    private KeyCode _rightKey = KeyCode.D;

    public KeyCode RightKey
    {
        get { return _rightKey; }
        set { _rightKey = value; }
    }

    private void Update()
    {
        //设置移动和缩放的默认值
        //Vector3 intos = gameObject.transform.position;
        //if (intos.y < -5600)
        //{
        //    moveSpeed = 80f;
        //    ScaleSpeed = 30f;
        //}
        //else if (intos.y > -5600)
        //{
        //    moveSpeed = 800f;
        //    ScaleSpeed = 3000f;
        //}
    }

    void Awake()
    {

    }

    void Start()
    {

    }

    void LateUpdate()
    {
        Vector3 oldPos = this.transform.position;

        //鼠标左键
        if (Input.GetMouseButton(0))
        {
            var position = transform.position;
            // transform.TransformDirection(Vector3.left) 变化方向从局部坐标转化到世界坐标，返回的是transform的left方向
            position += transform.TransformDirection(Vector3.left).normalized * (Input.GetAxis("Mouse X") * moveSpeed * 0.02f);
            position += transform.TransformDirection(Vector3.down).normalized * (Input.GetAxis("Mouse Y") * moveSpeed * 0.02f);

            movePosition(position);
        }

        //鼠标右键
        if (Input.GetMouseButton(1))
        {
            float x = 0;
            float y = 0;

            x += Input.GetAxis("Mouse X") * xRoatationSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * yRoatationSpeed * 0.02f;

            //限定y的最大值和最小值
            y = ClampAngle(y, yRoatationMinLimit, yRoatationMaxLimit);
            //旋转
            transform.Rotate(y, x, 0);
            //旋转的角度
            var angles = transform.eulerAngles;
            angles.z = 0;

            transform.eulerAngles = angles;
        }

        //鼠标滑轮
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            var moveDistance = Input.GetAxis("Mouse ScrollWheel") * ScaleSpeed;

            var position = transform.position;
            position += transform.TransformDirection(Vector3.forward).normalized * moveDistance;

            movePosition(position);
        }

        if (Input.GetKey(ForwardKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.forward).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(BackKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.back).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(LeftKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.left).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(RightKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.right).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(ForwardKey) || Input.GetKey(BackKey) || Input.GetKey(LeftKey) || Input.GetKey(RightKey))
        {
            KeyboardMoveSpeed += KeyboardMoveAcceleratedSpeed * 0.02f;
        }
        else
        {
            KeyboardMoveSpeed = DefaultKeyboardMoveSpeed;
        }

        if (Vector3.Distance(transform.position, Vector3.zero) > MaxMoveDistance)
        { 
            movePosition(oldPos + oldPos.normalized * -100);
        }
    }

    //移动的脚本，移动物体的刚体
    void movePosition(Vector3 moveToPosition)
    {
        if (transform.GetComponent<Rigidbody>())
        {
            if (!Physics.Raycast(transform.position, moveToPosition - transform.position, (moveToPosition - transform.position).magnitude))
            {
                transform.GetComponent<Rigidbody>().MovePosition(moveToPosition);
            }
        }
    }

    //限定y轴角度的最大和最小值
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
