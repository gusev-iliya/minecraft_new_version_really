using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobs : MonoBehaviour
{
    public GameObject Target; //текущая цель

   
    
    public float mobRotationSpeed = 2.5f; //скорость поворота моба
    public float attackDistance = 5.0f; //дистанция атаки
    public int damage = 5; //урон, наносимый мобом
    public float attackTimer = 0.0f; //переменная расчета задержки между ударами
    public const float coolDown = 2.0f; //константа, используется для сброса таймера атаки в начальное значение
    public float firerate = 10;
    public float MobCurrentSpeed = 5; //скорость моба, инициализируем позже
    private Transform mob;
    private float nt;
    void Start()
    {
        mob = transform;
    }

    // Update is called once per frame
    void Update()
    {
        mob.rotation = Quaternion.Lerp(mob.rotation, Quaternion.LookRotation(new Vector3(Target.transform.position.x, 0.0f, Target.transform.position.z) - new Vector3(mob.position.x, 0.0f, mob.position.z)), mobRotationSpeed); //избушка-избушка, повернись к пушке передом!
        mob.position += mob.forward * MobCurrentSpeed * Time.deltaTime; //двигаем в сторону, куда смотрит моб
        float distance = Vector3.Distance(Target.transform.position, mob.position); //меряем дистанцию до цели
        Vector3 structDirection = (Target.transform.position - mob.position).normalized; //получаем вектор направления
        float attackDirection = Vector3.Dot(structDirection, mob.forward); //получаем вектор атаки
        if (distance < attackDistance ) //если мы на дистанции атаки и цель перед нами
        {
            Debug.Log("youe");
            if (Time.time > nt) //если же он стал меньше нуля или равен ему
            {
                
                nt = Time.time + firerate;//подключаемся к компоненту ХП цели
                if (Target.GetComponent<HP>().hp <= 0) { Debug.Log("you die"); }
                if (Target.GetComponent<HP>().hp > 0) { Target.GetComponent<HP>().hp -= damage;
                    Debug.Log("damage");
                } //если цель ещё живая, наносим дамаг (мы можем не одни бить по цели, потому проверка необходима)
                attackTimer = coolDown;
               
            }
        }
    }
}

