using UnityEngine;
using System.Collections;

public class SawTransform : MonoBehaviour {
    public bool isLeft;
    Transform ThisTransform;
    private enum PositionStatus : int
    {
        Left = 0,
        Right = 1
    }
    PositionStatus sawPositionStatus;

    void Start () {
        if (isLeft)
            sawPositionStatus = PositionStatus.Left;
        else
            sawPositionStatus = PositionStatus.Right;
    }

    void Update() {
        if (isLeft)
        {
            ThisTransform = GetComponent<Transform>();
            ThisTransform.position += new Vector3(0.02f, 0f, 0f);
            if (ThisTransform.position.x >= -8.6f)
                isLeft = false;
        }
        else
        {
            ThisTransform = GetComponent<Transform>();
            ThisTransform.position -= new Vector3(0.02f, 0f, 0f);
            if (ThisTransform.position.x <= -9.4f)
                isLeft = true;
        }
    }
}
