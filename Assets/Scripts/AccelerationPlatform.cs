using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationPlatform : MonoBehaviour
{
    [SerializeField]
    private float accelForce;

    [SerializeField]
    private Vector3 direction;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.transform.CompareTag("Player") )
        {
            //사운드 재생
            audioSource.Play();

            //발판에 부딪힌 오브젝트에게 방향과 힘 전달
            collision.transform.GetComponent<Movement3D>().MoveTo(direction, accelForce);
        }
    }
}
