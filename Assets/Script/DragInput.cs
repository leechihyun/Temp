using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInput : MonoBehaviour
{
    [SerializeField] Vector2 startScreenPosition;        //터치 시작 지점
    [SerializeField] Vector2 currentScreenPosition;      //현재 터치 지점
    [SerializeField] Vector2 relativeScreenPosition;     //상대적 터치 지점 (시작 - 현재)
    [SerializeField] public static float dragNormalizeX { get; private set; } //드래그한 좌우 비율
    public static TouchPhase touchPhase { get; private set; }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPhase = touch.phase;

            switch (touch.phase)
            {
                //손가락이 화면을 터치하는 순간
                case TouchPhase.Began:
                    startScreenPosition = touch.position;
                    break;
                //손가락이 화면위에 터치한 상태로 이동하고 있는 상태
                case TouchPhase.Moved:
                    currentScreenPosition = touch.position;

                    relativeScreenPosition = currentScreenPosition - startScreenPosition;
                    dragNormalizeX = relativeScreenPosition.x / Screen.width;
                    break;
                //손가락이 화면을 터치했지만, 마지막 프레임에서 변화가 없음
                case TouchPhase.Stationary:
                    break;
                //손가락이 화면 위를 벗어나 떨어지게 되는 그 순간, 터치가 끝난 상태
                case TouchPhase.Ended:
                    startScreenPosition = Vector2.zero;
                    currentScreenPosition = Vector2.zero;
                    relativeScreenPosition = Vector2.zero;
                    dragNormalizeX = 0f;
                    break;
                //5개 이상의 터치입력이 동시발생하여 시스템이 터치의 추적을 취소한 상태
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
