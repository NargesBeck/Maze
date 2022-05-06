using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform CamTransform;

    private bool KeepLookingAt, KeepMovingForward;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            KeepLookingAt = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            KeepLookingAt = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            KeepMovingForward = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            KeepMovingForward = false;
        }

        KeepLookingAt = true;
        if (KeepLookingAt)
        {
            Debug.Log(Input.mousePosition);
            CamTransform.LookAt(Input.mousePosition);
            CamTransform.eulerAngles = new Vector3(0, CamTransform.eulerAngles.y, CamTransform.eulerAngles.z);
        }

        if (KeepMovingForward)
        {
            CamTransform.position += CamTransform.forward / 5;
        }
    }
}
