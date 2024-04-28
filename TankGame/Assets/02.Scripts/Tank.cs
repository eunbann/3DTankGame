using System.Collections; // ArrayList
using System.Collections.Generic; // LIst<>
using UnityEngine;

public class Tank : MonoBehaviour
{
    //멤버 변수
    //속도 = 거리 / 시간
    //거리 = 속도 * 시간 
    //탱크의 전후 이동
    public int moveSpeed; //속도
    public float move; //거리
    public float moveVertical;

    //탱크의 좌우 회전
    public int rotSpeed;
    public float rotate;
    public float rotHorizon;

    //Turret의 좌우 회전
    public float rotTurret;
    public GameObject turret;

    private Transform TnakBodyTr; //Tank의 Transform
    public int power; //포 발사 속도
    public GameObject bulletPrefab; //총알
    private Transform spPoint; //생성 위치

    //멤버 함수
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

        moveVertical = Input.GetAxis("Vertical"); //전후진 값
        rotHorizon = Input.GetAxis("Horizontal"); //회전 값
        rotTurret = Input.GetAxis("Window Shake X"); //포탑 회전

        transform.Translate(Vector3.forward * move * moveVertical);
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up * rotTurret * rotate);

        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼이 눌러졌다면
        {
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject;
            Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            bulletAddforce.AddForce(turret.transform.forward * power);
        }
    }
}