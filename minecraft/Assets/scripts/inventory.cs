using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public List<Item> item;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;
    public float range = 10000;
    public GameObject messageManager;
    public GameObject message;
    public GameObject player;
    public GameObject point;
    void Start()
    {
        item = new List<Item>();

        cellContainer.SetActive(false);

        for (int i =0; i< cellContainer.transform.childCount;i++ ) {
            item.Add(new Item());
            cellContainer.transform.GetChild(i).GetComponent<currentItem>().index = i;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(showInventory))
        {

            cellContainer.SetActive(!cellContainer.activeSelf);
            point.SetActive(!point.activeSelf);
            if (cellContainer.activeSelf)
            {
                player.GetComponent<movement_player>().enabled = false;
                player.GetComponent<MoveMouse>().enabled = false;
                player.GetComponent<cameramove>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
               
            }
            else
            {
                player.GetComponent<movement_player>().enabled = true;
                player.GetComponent<MoveMouse>().enabled = true;
                player.GetComponent<cameramove>().enabled = true;
            }

        }
        if (Input.GetKeyDown(takeButton))
        {
            Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item currentItem = hit.collider.GetComponent<Item>();
                    Message(currentItem);
                    AddItem(currentItem);
                }
            }
        }
    }

    void Message(Item currentItem)
    {
        GameObject msg = Instantiate(message);
        msg.transform.SetParent(messageManager.transform);
        Text txtmsg = msg.transform.GetChild(0).GetComponent<Text>();
        txtmsg.text = currentItem.nameItem;
    }
    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }
        else
        {
            AddUnstackableItem(currentItem);
        }
    }
    void AddUnstackableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == 0)
            {
                item[i] = currentItem.GetComponent<Item>();
                item[i].countItem = 1;
                DisplayItem();
                Destroy(currentItem.gameObject);
                break;
            }
        }
    }
    void AddStackableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == currentItem.id)
            {
                item[i].countItem++;
                DisplayItem();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        AddUnstackableItem(currentItem);
    }
    public void DisplayItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);
            Text txt = count.GetComponent<Text>();
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {

                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();
                }
                else
                {
                    txt.text = null;
              
                }
            }
            else
            {

                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }
}
