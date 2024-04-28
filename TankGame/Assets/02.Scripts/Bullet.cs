using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public int power = 500;
    public AudioClip sound;
    public GameObject exp;

    void Start()
    {
        //객체 - 컴포넌트 - 함()
        this.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
     
    void Update()
    {
        
    }

    //트리거가 체크되어 있을때 호출되는 함수(물리적인 속성 없음, 단순 충돌 검)
    void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        GameObject copy_exp = Instantiate(exp) as GameObject;

        if (col.gameObject.tag == "wall")
        {
            copy_exp.transform.position = col.transform.position; //폭팔 파티클을 생성시키는 위치 
            Destroy(col.gameObject); //벽을 없앰
        }
        else if (col.gameObject.tag == "ENEMY")
        {
            Score.Counter++;
            if (Score.Counter > 5)
            {
                //적 탱크 사라짐
                //승리 화면으로 전환 (씬 전환)
                SceneManager.LoadScene("Win");

            }
        }
        else if (col.gameObject.tag == "TANK")
        {
            Score.Hit++;
            if (Score.Hit > 5)
            {
                //내 탱크 사라짐
                //패배 화면으로 전환 
                SceneManager.LoadScene("Lose");
            }
        }
        copy_exp.transform.position = transform.position;
        Destroy(this.gameObject); //총알을 없앰
    }   
}
