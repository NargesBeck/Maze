using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameManager.DoorTypes DoorType;

    public void UnlockMeIfPossible()
    {
        if(GameManager.Instance.DoesHaveKeyFor(DoorType))
        {
            GameManager.Instance.DoorWasUnlocked();
            Destroy(gameObject);
        }
    }
}
