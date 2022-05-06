using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform CamTransform;

    private CharacterController characterController;
    private CharacterController CharacterController
    {
        get
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }
            return characterController;
        }
    }

    private bool KeepLookingAt, KeepMovingForward;
    private int RotationDelta;
    private int MovementDelta;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotationDelta = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotationDelta = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            RotationDelta = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovementDelta = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementDelta = -1;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            MovementDelta = 0;
        }

        if (RotationDelta != 0)
        {
            CamTransform.eulerAngles = new Vector3(0, CamTransform.eulerAngles.y + RotationDelta * 5, 0);
        }

        if (MovementDelta != 0)
        {
            MoveMe(MovementDelta);
            //CamTransform.position += CamTransform.forward / 5 * MovementDelta;
        }
    }

    private void MoveMe(int direction)
    {
        CharacterController.Move(CamTransform.forward / 5 * MovementDelta);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Key key = hit.gameObject.GetComponent<Key>();
        if (key != null)
        {
            key.IAmPickedUp();
        }
    }
    
}
