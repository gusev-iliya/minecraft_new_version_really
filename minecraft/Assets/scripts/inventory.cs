using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    List<Item> item;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;
    public float range = 10000;

    void Start()
    {
        item = new List<Item>();

        cellContainer.SetActive(false);

        for (int i =0; i< cellContainer.transform.childCount;i++ ) {
            item.Add(new Item());
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(showInventory))
        {
            cellContainer.SetActive(!cellContainer.activeSelf);
        }
        if (Input.GetKeyDown(takeButton))
        {
            Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item[i].id==0)
                        {
                            item[i] = hit.collider.GetComponent<Item>();
                            DisplayItem();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }
    void DisplayItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                Debug.Log("1");
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
            }
            else
            {
                Debug.Log("2");
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
}
