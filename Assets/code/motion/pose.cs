using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int currentPoseId = -1;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        string stateName;
        int poseId;

        //stste nameとunity内ステート名が一致している必要あり
        if (up && left) { stateName = "左上移動"; poseId = 5; }
        else if (up && right) { stateName = "右上移動"; poseId = 6; }
        else if (down && left) { stateName = "左下移動"; poseId = 7; }
        else if (down && right) { stateName = "右下移動"; poseId = 8; }
        else if (up) { stateName = "上移動"; poseId = 1; }
        else if (down) { stateName = "下移動"; poseId = 2; }
        else if (left) { stateName = "左移動"; poseId = 3; }
        else if (right) { stateName = "右移動"; poseId = 4; }
        else { stateName = "通常"; poseId = 0; }

        if (poseId != currentPoseId)
        {
            animator.Play(stateName, 0, 0f);
            currentPoseId = poseId;
        }
    }
}