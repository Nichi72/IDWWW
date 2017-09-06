using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;

namespace Pakage01
{
 

    public struct Obstruction_Status
    {
        public static int Obstruction_count = 0; // 현재 만들어진 방해물 수 
        public static int Total = 1000;

        public int name_number;
        public int incidence;// 방해물 출현률 방해물 출현률은 0 ~ 1 까지 이며  0.6을 작성하면 60퍼센트로 출현 함 
        public int power;


        

        public Obstruction_Status(Obstruction_Status status)
        {
            this.name_number = status.name_number;
            this.incidence = status.incidence;
            this.power = status.power;
            
        }

        public Obstruction_Status(int name_number, int incidence, int power)
        {
            this.name_number = name_number;
            this.incidence = incidence;
            this.power = power;
        }


    }

    public struct Stage_Status // 수정중 예전 버전임 
    {
        public int number_restrictions; // 방해물 제한개수 
        public int stage_number; // 몇번째 스테이지
        public float stage_length;//스테이지 총 길이  
        public float stage_speed; // 스테이지 속도 

        public Stage_Status(Stage_Status status)
        {
            this.number_restrictions = status.number_restrictions;
            this.stage_number = status.stage_number;
            this.stage_length = status.stage_length;
            this.stage_speed = status.stage_speed;
        }

        public Stage_Status(int number_restrictions, int stage_number, float stage_length, float stage_speed)
        {
            this.number_restrictions = number_restrictions;
            this.stage_number = stage_number;
            this.stage_length = stage_length;
            this.stage_speed = stage_speed;
        }
    }


    public static class GameBalancer
    {
        
        public enum Obstruction_enum { Girls_AR, Girls_HG, Girls_MG, Girls_SG, Girls_SMG ,      //기본 방해물 
                                       Iron_dangdang, Iron_parkG, Iron_Uroboros    //스테이지 1번
                                             
        };
        
        public static Obstruction_Status[] Girls_status = new Obstruction_Status[5]
        {
            
            //인수값               (int name_number, float incidence, float power) // 200 100 50 50  100 200 
            new Obstruction_Status((int)Obstruction_enum.Girls_AR, 125,125),  
            new Obstruction_Status((int)Obstruction_enum.Girls_HG, 125,125),
            new Obstruction_Status((int)Obstruction_enum.Girls_MG, 125,125),
            new Obstruction_Status((int)Obstruction_enum.Girls_SG, 125,125),
            new Obstruction_Status((int)Obstruction_enum.Girls_SMG,125,125)
        };

        public static Obstruction_Status[] Iron_status = new Obstruction_Status[3]
       {
            //인수값              (string name, float incidence, float power, float speed, float scale) // 
            new Obstruction_Status((int)Obstruction_enum.Iron_dangdang, 125,125),  // name이 곧 스테이지 넘버 
            new Obstruction_Status((int)Obstruction_enum.Iron_parkG, 125,125),
            new Obstruction_Status((int)Obstruction_enum.Iron_Uroboros, 125,125)

       };

        public static Stage_Status[] stage_Status = new Stage_Status[3]
        {
            //인수값
            //public Stage_Status(int number_restrictions, int stage_number, float stage_length, float stage_speed)
            new Stage_Status(0, 0,0f,0f),// 0번 인덱스 더미
            new Stage_Status(10, 1,120f,5f),
            new Stage_Status(12, 2,120f,5f)
        };
    }

  
}

//public class Status : MonoBehaviour
//{
//    void Start()
//    {
//        //StartCoroutine(setting_states());
//    }

//    public virtual IEnumerator setting_states()
//    {
//        while (true)
//        {
//            GetComponent<Rigidbody>().velocity = new Vector3(0, -GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
//            yield return new WaitForSeconds(0.1f);
//        }
//    }

//    public virtual void Test()
//    {
//        Debug.Log("***************TEST1*******************");
//    }


//    
//}


//public class Asteroid : Status
//{
//    public override IEnumerator setting_states()
//    {
//        while (true)
//        {
//            Debug.Log("이거 실행 된다");
//            GetComponent<Rigidbody>().velocity = new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
//            yield return new WaitForSeconds(0.1f);
//        }
//    }


