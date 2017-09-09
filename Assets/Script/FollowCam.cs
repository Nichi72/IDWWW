using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform IDWtr;      //추적할 타겟 게임오브젝트의 Transform 변수
    public float differencePower;       // 얼마나 IDW의 영향을 받을 것인가
    float postion_zPower;         // differencePower 영향을 받은 변수
    public float dist = 10.0f;      //카메라와의 일정 거리
    public float height = 3.0f;     //카메라의 높이 설정
    public float dampTrace = 20.0f; //부드러운 추적을 위한 변수
    Vector3 distanceDifferenceTraffic;  // 이전 프레임과 현재의 프레임의 차이량을 구하기 위해 필요한 변수 
    Vector3 temp;              // temp가 이전 프레임을 담는 변수임 
    //카메라 자신의 Transform 변수
    public Transform cameratr;
    public Camera _camera;
    float clampY; // IDW 의 Y축에 비례해서 Size값이 증감한다. 이 변수는 clamp로 제한받아 최소값가 최대값이 존재한다. 
    
    void Start()
    {
        differencePower = 0.5f;
        //_camera = GetComponent<Camera>();
        temp = IDWtr.position;
        distanceDifferenceTraffic = IDWtr.position; // 초기화 
        StartCoroutine(CameraSize());
        
        //StartCoroutine(clampTest()); // 테스트 코루틴 
        //GetComponent<Rigidbody>().
    }

    //Update 함수 호출 이후 한번씩 호출되는 함수인 LateUpdate 사용
    //추적할 타겟의 이동이 종료된 이후에 카메라가 추적하기 위해 LateUpdate 사용    
    //void LateUpdate()
    //{
    //    //clampTest();
    //    postion_zPower = IDWtr.position.y * differencePower; //differencePower 영향을 받은 변수

    //    //Debug.Log("DifferenceTraffic() 값 " + DifferenceTraffic());

    //    cameratr.position = new Vector3(IDWtr.position.x+5, IDWtr.position.y +4.5f , IDWtr.position.y -20f);
    //    //cameratr.position += new Vector3(cameratr.position);
    //    //_camera.orthographicSize =+ 0.5f * DifferenceTraffic();

    //}

    int DifferenceTraffic() // 이전 프레임의 차이량을 구하는 함수 올라가면 +1 값 떨어지면 -1
    {
        distanceDifferenceTraffic.y = IDWtr.position.y - temp.y;
        temp.y = IDWtr.position.y;
        //Debug.Log("IDWtr.position.y : " + IDWtr.position.y + "  temp.y : " + temp.y + "  distanceDifferenceTraffic.y : " + distanceDifferenceTraffic.y +"  :::::"+
        //    (int)(distanceDifferenceTraffic.y / distanceDifferenceTraffic.y));
        if (distanceDifferenceTraffic.y == 0)
        {
            return 1;
        }
        else
        return (int)(distanceDifferenceTraffic.y / distanceDifferenceTraffic.y);
    }

    //IEnumerator clampTest()
    //{
    //    while (true)
    //    {
    //        float Testint = cameratr.transform.position.x;
    //        float TestClamp = Mathf.Clamp(cameratr.transform.position.x, 30f, 70f);


    //        Debug.Log("clamp TestClamp : " + Mathf.Clamp(TestClamp, 30f, 70f) + " original Testint " + Testint);
    //        cameratr.transform.Translate(TestClamp, 0,0);
    //        Debug.Log(" clamp IDWtr.transform.position.x : " + Mathf.Clamp(cameratr.transform.position.x, 30f, 70f) + " original Testint " + Testint);
    //        Debug.Log("=====================================================================================");



    //        yield return new WaitForSeconds(1f);
    //    }


    //}

    public IEnumerator CameraSize() // IDW 의 Y축에 비례하며 카메라 SIze값이 증감한다.
    {
        while (true)
        {
            cameratr.position = new Vector3(IDWtr.position.x + 5, IDWtr.position.y + 6.5f, IDWtr.position.z -20f);
            clampY = (IDWtr.transform.position.y * DifferenceTraffic());
            _camera.orthographicSize = Mathf.Clamp(clampY, 4.5f, 20f);
            yield return null;
        }
    }




    float myclamp(float value , float min , float max) // clamp 내가 만들었는데 안씀 ㅋㅋ
    {
        if (min > value) // 4 > 0 -> 4 > 4 
        {
            value = min;
        }
        if ( max < value ) // 100 < 120 -> 100 < 100 
        {
            value = max;
        }
        return value;
    }








    //if (targetTr.position.y b) 
    //tr.rotation = (new Quaternion(16, 0, 0,0));

    //tr.position = Vector3.Lerp(tr.position
    //                            , targetTr.position
    //                              + (-targetTr.forward * dist)
    //                              , Time.deltaTime * dampTrace);


    //카메라가 타겟 게임오브젝트를 바라보게 설정                            
    //tr.LookAt(targetTr.position);
    //_camera.





}
