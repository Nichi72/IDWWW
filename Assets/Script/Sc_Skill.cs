using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Skill : MonoBehaviour {
    public GameObject mainCameraObj; // 카메라 게임 오브젝트
    public Camera camera_;           // 진짜 카메라 
    public GameObject Skiller;
    public GameObject bullet;
    public Transform bulletTr;
    public Transform bulletStartTr;
    public Transform SkillerCameraTr;
    public GameObject IDW;// 실제 IDW 위치 
   
    public AudioClip audioClip;
    GameObject BulletObj;
    // Use this for initialization
    void Start () {

        
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void startSkill()
    {
        camera_.orthographic = false;
        
        onSkill();
        Debug.Log("startSkill() 들어왔음");
        
    }

    public void onSkill()
    {
        bool check = mainCameraObj.GetComponent<FollowCam>().enabled = false;
        while (!check) // 무한 와일문으로 FollowCam 이 꺼졌는지 켜졌는지 체크한다. enable가 false 상태 일때 실행 된다. 
        {
            
            if (!check) // 
            {
                Debug.Log("bool check= mainCameraObj.GetComponent<FollowCam>().enabled = false;");
                StartCoroutine(CameraWorkingToSkillerTr());
                break;
            }
            
        }
            
        
                                                                                          
                                                                                        // 총알을 따라서 카메라가 따라감       
    }
    public IEnumerator CameraWorkingToSkillerTr() // 메인 카메라를 스킬 쓰는 곳으로 옮긴 후 총알 생성 후 코루틴 시작 "CameraWorkingToBulletTr()"
    {
        
        mainCameraObj.transform.rotation = SkillerCameraTr.transform.rotation;
        BulletObj = Instantiate(bullet, bulletStartTr.position, bullet.transform.rotation);
        while ((int)mainCameraObj.transform.position.x != (int)BulletObj.transform.GetChild(0).transform.position.x) // 같아지면 와일문 통과 
        {
            mainCameraObj.transform.position = Vector3.Lerp(mainCameraObj.transform.position, BulletObj.transform.GetChild(0).transform.position, 0.03f); // 메인카메라를 스킬쓰는곳으로 옮긴다. 
            yield return null;
        }
        StopCoroutine(this.CameraWorkingToSkillerTr());
        
        
        SoundManager._instence.PlaySE(audioClip);
        StartCoroutine(CameraWorkingToBulletTr());
        // 총알 사운드
        // 탕! 효과가 있었으면 좋겠음
        Debug.Log("CameraWorkingToSkillerTr() 코루틴 종료 되었음");
    }

    public IEnumerator CameraWorkingToBulletTr() // 총알을 쏴서 IDW를 따라가게 함과 동시에 메인 카메라가 총알을 따라가게 만드는 코루틴
    {
        float distance = Vector3.Distance(bulletStartTr.position, IDW.transform.position); // "총알 발사 지점" 이랑 IDW 사이의 거리 
        float nowPos=0;

        while ((int)BulletObj.transform.position.x != (int)IDW.transform.position.x) // 같아지면 와일문 통과
        {


           if (nowPos < distance*0.3) // 
            {
                nowPos = 0.01f;
            }
           else if (nowPos < distance * 0.6)
            {
                nowPos = 0.5f;
            }
           else if (nowPos <= distance)
            {
                nowPos = 20f;
            }

            Debug.Log("nowPos :: " +nowPos);
            
            BulletObj.transform.position = Vector3.Lerp(BulletObj.transform.position, IDW.transform.position, nowPos); // 총알을 IDW있는 곳으로 
            mainCameraObj.transform.position = Vector3.Lerp(mainCameraObj.transform.position, BulletObj.transform.GetChild(0).transform.position, 20f); // 메인카메라가 총알을 따라가게 
            yield return null;
        }
        Debug.Log("CameraWorkingToBulletTr() 코루틴 종료 되었음");
    }
 
    
        
    //public IEnumerator CameraWorkingToSkillerTr() // 실행 안됨 // 이 친구는 와일문은 트루이지만 중간에 이프문으로 조건을 걸은 후 스탑 코루틴을 쓰려고 했다. 하지만 안됨 
    //{
    //    while (true) // 같아지면 와일문 통과 
    //    {
    //        mainCameraObj.transform.position = Vector3.Lerp(mainCameraObj.transform.position, SkillerCameraTr.transform.position, 0.05f);
    //        if ((int)mainCameraObj.transform.position.x != (int)SkillerCameraTr.transform.position.x)
    //        {
    //            StopCoroutine(this.CameraWorkingToSkillerTr());
    //            Debug.Log("CameraWorkingToSkillerTr() 코루틴 종료 되었음");
    //        }
    //        yield return null;
    //    }
    //}
}
