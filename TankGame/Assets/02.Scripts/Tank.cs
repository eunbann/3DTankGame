using System.Collections; // ArrayList
using System.Collections.Generic; // LIst<>
using UnityEngine;

public class Tank : MonoBehaviour
{
    //��� ����
    //�ӵ� = �Ÿ� / �ð�
    //�Ÿ� = �ӵ� * �ð� 
    //��ũ�� ���� �̵�
    public int moveSpeed; //�ӵ�
    public float move; //�Ÿ�
    public float moveVertical;

    //��ũ�� �¿� ȸ��
    public int rotSpeed;
    public float rotate;
    public float rotHorizon;

    //Turret�� �¿� ȸ��
    public float rotTurret;
    public GameObject turret;

    private Transform TnakBodyTr; //Tank�� Transform
    public int power; //�� �߻� �ӵ�
    public GameObject bulletPrefab; //�Ѿ�
    private Transform spPoint; //���� ��ġ

    //��� �Լ�
    void Start()
    {
        moveSpeed = 8;
        rotSpeed = 120;
        power = 600;
        TnakBodyTr = GetComponent<Transform>();
        spPoint = GameObject.Find("spPoint").transform;
    }

    void Update()
    {
        move = moveSpeed * Time.deltaTime;
        rotate = rotSpeed * Time.deltaTime;

        moveVertical = Input.GetAxis("Vertical"); //������ ��
        rotHorizon = Input.GetAxis("Horizontal"); //ȸ�� ��
        rotTurret = Input.GetAxis("Window Shake X"); //��ž ȸ��

        transform.Translate(Vector3.forward * move * moveVertical);
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up * rotTurret * rotate);

        if (Input.GetMouseButtonDown(0)) //���� ���콺 ��ư�� �������ٸ�
        {
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject;
            Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            bulletAddforce.AddForce(turret.transform.forward * power);
        }
    }
}