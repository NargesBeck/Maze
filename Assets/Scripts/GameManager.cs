using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
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
    private const int DoorPink = 0b_0010;
    private const int DoorYellow = 0b_0100;

    [SerializeField]
    private TextMesh TextInventory;
    [SerializeField]
    private TextMesh TextLogs;

    public enum DoorTypes
    {
        Blue = DoorBlue, Pink = DoorPink, Yellow = DoorYellow
    }

    private int KeysInventory;

    private void Start()
    {
        LogKeyInventoryOnTextMesh();
    }

    public bool DoesHaveKeyFor(DoorTypes door)
    {
        return (KeysInventory & (int)door) != 0;
    }

    public void JustCollectedKey(DoorTypes key)
    {
        KeysInventory |= (int)key;
        LogKeyInventoryOnTextMesh();
        LogKeyEvent();
    }

    public void DoorWasUnlocked()
    {
        LogDoorEvent();
    }

    private void LogKeyInventoryOnTextMesh()
    {
        TextInventory.text = System.Convert.ToString(KeysInventory, 2);
    }

    private void LogKeyEvent()
    {
        string keyEvent = "Key was added to inventory.";
        LogEvent(keyEvent);
    }

    private void LogDoorEvent()
    {
        string doorEvent = "Door unlocked.";
        LogEvent(doorEvent);
    }

    private void LogEvent(string content)
    {
        TextLogs.gameObject.SetActive(true);
        TextLogs.text = content;
        StopAllCoroutines();
        StartCoroutine(DelayToDissappearLogs());
    }

    private IEnumerator DelayToDissappearLogs()
    {
        yield return new WaitForSecondsRealtime(2);
        TextLogs.gameObject.SetActive(false);
    }
}
