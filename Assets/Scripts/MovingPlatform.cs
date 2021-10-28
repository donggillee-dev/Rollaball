using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints; //이동 가능 지점들

    [SerializeField]
    private float waitTime; //wayPoint 도착 후 대기시간

    [SerializeField]
    private float moveSpeed; //이동 속도

    private int wayPointCount; //이동 가능한 wayPoint 개수
    private int currentIndex = 0; //현재 wayPoint 인덱스

    private void Awake()
    {
        wayPointCount = wayPoints.Length;
        
        //최초 오브젝트 위치 설정
        transform.position = wayPoints[currentIndex].position;

        currentIndex ++;

        StartCoroutine("MoveTo");
    }

    private IEnumerator MoveTo()
    {
        while( true )
        {
            //wayPoints[currentState].position까지 이동
            yield return StartCoroutine("Movement");

            //waitTime시간 동안 대기
            yield return new WaitForSeconds(waitTime);

            //다음 웨이포인트 설정
            if( currentIndex < wayPointCount - 1 )
            {
                currentIndex ++;
            }
            else {
                currentIndex = 0; //마지막 wayPoint이면 0으로 초기화
            }
        }
    }

    private IEnumerator Movement()
    {
        while( true )
        {
            //목표 위치로 가는 이동 방향 = 목표 위치 - 내 위치
            //noramlized 해주지 않으면 멀수록 속도가 빨라진다
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;

            //오브젝트 이동(방향 * 속도 * Time.deltaTime)
            transform.position += direction * moveSpeed * Time.deltaTime;

            //목표 위치에 거의 도달했을 때 ( 현재 위치와 목표 위치의 거리 값이  0.1 미만 )
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.1f)
            {
                transform.position = wayPoints[currentIndex].position;
                break;
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //플레이어 오브젝트를 플랫폼의 자식으로 설정
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //플레이어 오브젝트를 플랫폼의 자식에서 해제
            collision.transform.SetParent(null);
        }
    }
}
