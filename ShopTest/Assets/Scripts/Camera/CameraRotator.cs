using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    Camera cam;
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;

    public float zoomSpeed = .1f;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    private void PitchZoom()
    {
        Touch touchOne = Input.GetTouch(0);
        Touch touchTwo = Input.GetTouch(1);

        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
        Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

        float prevTouchDelta = (touchOnePrevPos - touchTwoPrevPos).magnitude;
        float touchDelta = (touchOne.position - touchTwo.position).magnitude;

        float deltaMagnitude = prevTouchDelta - touchDelta;

        cam.orthographicSize += deltaMagnitude * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 5f, 50f);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2)
            {
                PitchZoom();
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                    this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }
        }

    }

}
