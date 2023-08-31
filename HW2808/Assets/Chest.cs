using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ChestBase
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!IsChestOpened)
            {
                OpenChest();
            }
        }
    }
}
