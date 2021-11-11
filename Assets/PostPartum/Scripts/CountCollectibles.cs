using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountCollectibles : MonoBehaviour
{
    public UnityEvent OnCollectiblesCollectedEvent;
    
    public int TotalCollectibles = 8;
    
    public static int CollectiblesCount = 0;

    public bool IsAllCollectiblesCollected = false;

    public GameObject ChildRoomBarrier;
    
    // Start is called before the first frame update
    void Start()
    {
        ChildRoomBarrier = GameObject.FindWithTag("ChildRoomBarrier");
        
        if (OnCollectiblesCollectedEvent == null)
            OnCollectiblesCollectedEvent = new UnityEvent();

        OnCollectiblesCollectedEvent.AddListener(RemoveChildRoomBarrier);
    }

    // Update is called once per frame
    void Update()
    {
        if (CollectiblesCount == TotalCollectibles)
        {
            if (!IsAllCollectiblesCollected)
            {
                IsAllCollectiblesCollected = true;
                if (OnCollectiblesCollectedEvent != null)
                {
                    OnCollectiblesCollectedEvent.Invoke();
                }
            }
        }
    }

    public void RemoveChildRoomBarrier()
    {
        if (ChildRoomBarrier != null)
        {
            ChildRoomBarrier.SetActive(false);
        }
    }
}
