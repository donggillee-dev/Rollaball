using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬에 관한 제어

public class StageController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName; //다음 씬의 이름

    [SerializeField]
    private GameObject panelStageClear; //스테이지 클리어 나타내는 Panel UI

    private int maxCoinCount;
    private int currentCoinCount;
    private bool getAllCoins = false; //모든 코인 획득 시 true

    public int MaxCoinCount => maxCoinCount;
    public int CurrentCoinCount => currentCoinCount;

    private void Awake()
    {
        //시간배율을 1로 설정해 정상속도로 재생
        Time.timeScale = 1.0f;

        //모든 코인을 획득했을 떄 등장 panelStageClear 오브젝트 초기에는 비활성화
        panelStageClear.SetActive(false);

        //태그가 COin인 오브젝트의 개수를 maxCoinCount에 저장(Map에 배치된 코인의 개수)
        maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        currentCoinCount = maxCoinCount;
    }

    private void Update()
    {
        if( getAllCoins == true )
        {
            //엔터키를 누르게되면
            if( Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextSceneName); //다음 씬으로 이동
            }
        }
    }

    public void GetCoin()
    {
        //현재 코인의 개수 --
        currentCoinCount--;

        if(currentCoinCount == 0)
        {
            //스테이지 클리어
            getAllCoins = true;
            Time.timeScale = 0.0f; //시간 정지
            panelStageClear.SetActive(true); //패널 오브젝트 활성화
        }
    }
}
