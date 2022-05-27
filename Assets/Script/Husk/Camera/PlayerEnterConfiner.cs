﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEnterConfiner : MonoBehaviour
{
    public event Action<uint, bool> ActiveRoomEvent;
    private PolygonCollider2D polygonCollider2D;
    // [SerializeField] private float lensSize;
    [SerializeField] private uint stageIndex;
    private void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();

        ActiveRoomEvent += FindObjectOfType<RoomManager>().RoomChange;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log($"stage {stageIndex} - Enter");
            ActiveRoomEvent?.Invoke(stageIndex, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log($"stage {stageIndex} - Exit");
            ActiveRoomEvent?.Invoke(stageIndex, false);
        }
    }
}
