using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class building : MonoBehaviour
{
    public float maxDistance = 0.0f;
    public int curIndex = 0;
    public List<GameObject> Cubes = new List<GameObject>();

    public GameObject Prefab ;

    public List<Image> Slots = new List<Image>();
    public List<GameObject> selectSlot = new List<GameObject>();

    private Ray p_ray;
    private RaycastHit p_hit;
    private Vector2 p_rayDirection;
    private Camera m_Camera;


    private void Start()
    {
        m_Camera = Camera.main;
        p_rayDirection = new Vector2(Screen.width / 2, Screen.height / 2);
        //Prefab.SetActive(false);

        for (int i = 0; i < Cubes.Count; i++)
        {
            Slots[i].sprite = Cubes[i].GetComponent<Cube>().Avatar;
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            selectSlot[curIndex].SetActive(false);
            curIndex += Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel"));
            if (curIndex > Cubes.Count - 1)
            {
                curIndex = 0;
            }
            else if (curIndex < 0)
            {
                curIndex = Cubes.Count - 1;
            }
            selectSlot[curIndex].SetActive(true);
        }


        p_ray = m_Camera.ScreenPointToRay(p_rayDirection);
        if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider != null)
        {
            if (p_hit.collider.tag == "Ground")
            {
                //Prefab.transform.position = p_hit.collider.transform.position;
                //Prefab.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (p_hit.collider.transform.position.x - p_hit.point.x >= 0.5f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x - 1.0f, p_hit.collider.transform.position.y, p_hit.collider.transform.position.z);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }
                    else if (p_hit.collider.transform.position.x - p_hit.point.x <= -0.49f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x + 1.0f, p_hit.collider.transform.position.y, p_hit.collider.transform.position.z);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }
                    else if (p_hit.collider.transform.position.y - p_hit.point.y >= 0.5f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y - 1.0f, p_hit.collider.transform.position.z);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }
                    else if (p_hit.collider.transform.position.y - p_hit.point.y <= -0.5f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y + 1.0f, p_hit.collider.transform.position.z);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }
                    else if (p_hit.collider.transform.position.z - p_hit.point.z >= 0.5f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y, p_hit.collider.transform.position.z - 1.0f);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }
                    else if (p_hit.collider.transform.position.z - p_hit.point.z <= -0.5f)
                    {
                        var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y, p_hit.collider.transform.position.z + 1.0f);
                        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
                    }

                }
            }
            else
            {
                //Prefab.SetActive(false);
            }
        }
    }

    public void SelectCube(int indexInList)
    {

        if ((Cubes.Count - 1) < indexInList)
        {
            return;
        }

        selectSlot[curIndex].SetActive(false);
        if (indexInList > Cubes.Count - 1)
        {
            curIndex = 0;
        }
        else if (indexInList < 0)
        {
            curIndex = Cubes.Count - 1;
        }
        else
        {
            curIndex = indexInList;
        }
        selectSlot[curIndex].SetActive(true);
    }
}
