using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private const int DoorBlue = 0b_0001;
    private const int DoorRed = 0b_0010;
    private const int DoorYellow = 0b_0100;

    public enum DoorTypes
    {
        Blue = DoorBlue, Red = DoorRed, Yellow = DoorYellow
    }

    private int KeysInventory;

    public bool DoesHaveKeyFor(DoorTypes door)
    {
        return (KeysInventory & (int)door) != 0;
    }
}
