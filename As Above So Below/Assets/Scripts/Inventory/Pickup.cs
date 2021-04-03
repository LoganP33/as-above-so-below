using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.itemSlots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    // item is added to inventory
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
}
