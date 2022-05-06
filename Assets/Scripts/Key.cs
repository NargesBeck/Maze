using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameManager.DoorTypes KeyType;

    public void IAmPickedUp()
    {
        GameManager.Instance.JustCollectedKey(KeyType);
        Destroy(gameObject);
    }
}
