using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class currentItem : MonoBehaviour, IPointerClickHandler
{
    GameObject inventoryObj;
    inventory inventory;
    public int index;
    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("InventoryManager");
        inventory = inventoryObj.GetComponent<inventory>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.item[index].id != 0)
            {
                GameObject droped = Instantiate(Resources.Load<GameObject>(inventory.item[index].pathPrefab)) as GameObject;
                droped.transform.position = Camera.main.transform.position + Camera.main.transform.forward*2f;
                if (inventory.item[index].countItem > 1)
                {
                    inventory.item[index].countItem--;
                }
                else
                {
                    inventory.item[index] = new Item();
                }
                inventory.DisplayItem();
            }
        }
        //throw new System.NotImplementedException();
    }

  

    
}
