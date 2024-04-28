using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY : MonoBehaviour
{
    /*private Transform EspPoint; // 생성 위치
    public int Epower; // 포 발사 속도
    public GameObject Eturret;
    public GameObject EbulletPrefab; // 총알


    private NavMeshAgent nvAgent; // 따라오기를 해주는 컴포넌트
    private Transform target; // 플레이어 탱크의 위치
    private float distance; // 아군 탱크와 적 탱크 사이의 거리
    private float fTime; // 총알이 나가는 시간 (주기)

void Start()
    {
        target = GameObject.FindGameObjectWithTag("TANK").GetComponent<Transform>();
        fTime = 0.0f;
        EspPoint = GameObject.Find("EspPoint").transform; // 월드 상에서 객체를 찾아오는 역할 함

        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        fTime += Time.deltaTime;

        if(distance < 10.0f)
        {
            nvAgent.destination = target.position;
            //총알 나가는 주기를 셋팅
            if (fTime > 0.5f)
            {
                //총알 나가기 구현(2)
                //GameObject bullet = Instantiate(EbulletPrefab, EspPoint.position, EspPoint.rotation) as GameObject;
                fTime = 0.0f;
            }
        }
    }*/


    /*public GameObject bullet;
    public GameObject spPoint;

    private int rotAngle;
    private float amtToRot;
    private int power;
    private Vector3 direction;
    private float moveSpeed;*/

    //private Vector3 direction;
    private Transform EspPoint; // 생성 위치
    public int Epower; // 포 발사 속도
    public GameObject Eturret;
    public GameObject EbulletPrefab; // 총알

    private NavMeshAgent nvAgent; // 따라오기를 해주는 컴포넌트
    private Transform target; // 플레이어 탱크의 위치
    private float distance; // 아군 탱크와 적 탱크 사이의 거리
    private float fTime; // 총알이 나가는 시간 (주기)

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("TANK").GetComponent<Transform>();

        //moveSpeed = 1.0f;
        //power = 10;
        //rotAngle = 15;

        fTime = 0.0f;
        EspPoint = GameObject.Find("EspPoint").transform;

        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        //direction = target.transform.position - this.transform.position;

        distance = Vector3.Distance(target.transform.position, this.transform.position);
        fTime += Time.deltaTime;

        if (distance < 10.0f)
        {
            //this.transform.LookAt(target.transform.position);
            //amtToRot = rotAngle * Time.deltaTime;
            //transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
            //this.transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);

            nvAgent.destination = target.position;

            //총알 나가는 주기를 셋팅
            if (fTime > 0.5f)
            {
                //GameObject obj = Instantiate(bullet) as GameObject;
                //obj.transform.position = spPoint.transform.position;
                //obj.GetComponent<Rigidbody>().AddForce(direction * power);

                GameObject bullet = Instantiate(EbulletPrefab, EspPoint.position, EspPoint.rotation) as GameObject;

                Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
                bulletAddforce.AddForce(Eturret.transform.forward * Epower);

                fTime = 0.0f;
            }
        }
    }
}
