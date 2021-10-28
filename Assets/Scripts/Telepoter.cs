using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepoter : MonoBehaviour
{
    [SerializeField]
    private Transform arrivePoint;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //오브젝트 태그가 Player이면
        if(other.CompareTag("Player"))
        {
            //오디오 재생
            audioSource.Play();

            //플레이어의 위치를 arrivePoint로 지정
            other.transform.position = arrivePoint.position;
        }
    }
}
