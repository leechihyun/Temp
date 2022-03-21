using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInput : MonoBehaviour
{
    [SerializeField] Vector2 startScreenPosition;        //��ġ ���� ����
    [SerializeField] Vector2 currentScreenPosition;      //���� ��ġ ����
    [SerializeField] Vector2 relativeScreenPosition;     //����� ��ġ ���� (���� - ����)
    [SerializeField] public static float dragNormalizeX { get; private set; } //�巡���� �¿� ����
    public static TouchPhase touchPhase { get; private set; }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPhase = touch.phase;

            switch (touch.phase)
            {
                //�հ����� ȭ���� ��ġ�ϴ� ����
                case TouchPhase.Began:
                    startScreenPosition = touch.position;
                    break;
                //�հ����� ȭ������ ��ġ�� ���·� �̵��ϰ� �ִ� ����
                case TouchPhase.Moved:
                    currentScreenPosition = touch.position;

                    relativeScreenPosition = currentScreenPosition - startScreenPosition;
                    dragNormalizeX = relativeScreenPosition.x / Screen.width;
                    break;
                //�հ����� ȭ���� ��ġ������, ������ �����ӿ��� ��ȭ�� ����
                case TouchPhase.Stationary:
                    break;
                //�հ����� ȭ�� ���� ��� �������� �Ǵ� �� ����, ��ġ�� ���� ����
                case TouchPhase.Ended:
                    startScreenPosition = Vector2.zero;
                    currentScreenPosition = Vector2.zero;
                    relativeScreenPosition = Vector2.zero;
                    dragNormalizeX = 0f;
                    break;
                //5�� �̻��� ��ġ�Է��� ���ù߻��Ͽ� �ý����� ��ġ�� ������ ����� ����
                case TouchPhase.Canceled:
                    startScreenPosition = Vector2.zero;
                    currentScreenPosition = Vector2.zero;
                    relativeScreenPosition = Vector2.zero;
                    dragNormalizeX = 0f;
                    break;
                default:
                    break;
            }

        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    startScreenPosition = Input.mousePosition;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    currentScreenPosition = Input.mousePosition;

        //    relativeScreenPosition = currentScreenPosition - startScreenPosition;
        //    dragNormalizeX = relativeScreenPosition.x / Screen.width;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{

        //}
    }
}
