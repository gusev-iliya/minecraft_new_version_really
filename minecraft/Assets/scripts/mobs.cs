using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobs : MonoBehaviour
{
    public GameObject Target; //������� ����

   
    
    public float mobRotationSpeed = 2.5f; //�������� �������� ����
    public float attackDistance = 5.0f; //��������� �����
    public int damage = 5; //����, ��������� �����
    public float attackTimer = 0.0f; //���������� ������� �������� ����� �������
    public const float coolDown = 2.0f; //���������, ������������ ��� ������ ������� ����� � ��������� ��������
    public float firerate = 10;
    public float MobCurrentSpeed = 5; //�������� ����, �������������� �����
    private Transform mob;
    private float nt;
    void Start()
    {
        mob = transform;
    }

    // Update is called once per frame
    void Update()
    {
        mob.rotation = Quaternion.Lerp(mob.rotation, Quaternion.LookRotation(new Vector3(Target.transform.position.x, 0.0f, Target.transform.position.z) - new Vector3(mob.position.x, 0.0f, mob.position.z)), mobRotationSpeed); //�������-�������, ��������� � ����� �������!
        mob.position += mob.forward * MobCurrentSpeed * Time.deltaTime; //������� � �������, ���� ������� ���
        float distance = Vector3.Distance(Target.transform.position, mob.position); //������ ��������� �� ����
        Vector3 structDirection = (Target.transform.position - mob.position).normalized; //�������� ������ �����������
        float attackDirection = Vector3.Dot(structDirection, mob.forward); //�������� ������ �����
        if (distance < attackDistance ) //���� �� �� ��������� ����� � ���� ����� ����
        {
            Debug.Log("youe");
            if (Time.time > nt) //���� �� �� ���� ������ ���� ��� ����� ���
            {
                
                nt = Time.time + firerate;//������������ � ���������� �� ����
                if (Target.GetComponent<HP>().hp <= 0) { Debug.Log("you die"); }
                if (Target.GetComponent<HP>().hp > 0) { Target.GetComponent<HP>().hp -= damage;
                    Debug.Log("damage");
                } //���� ���� ��� �����, ������� ����� (�� ����� �� ���� ���� �� ����, ������ �������� ����������)
                attackTimer = coolDown;
               
            }
        }
    }
}

