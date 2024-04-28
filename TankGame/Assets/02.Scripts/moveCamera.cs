using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;

    void Start()
    {
        pos = this.transform.position;
    }

    void Update()
    {
        this.transform.position = pos + player.transform.position;
        //카메라.변환.위치 값 =  일정 거리 값 + 탱크.변.위치 값
    }
}
