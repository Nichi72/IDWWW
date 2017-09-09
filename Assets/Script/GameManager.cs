using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;

public class GameManager : MonoBehaviour {
    /*
     * 20170816 작업 내용
            Plane의 간격은 100으로 한다. 
            30 0 0
            130 
            게임매니저 : 

            오브젝트를 만들때

            카메라 안에서 들어오게 되면 보여주고 카메라 밖으로 나가면 보이지 않게 한다. 
            나가면보이지 않는다 
            -> 뒤에 보이지 않는 것은 사라지게 하고 
            일정 거리 앞(100)에 생성한다. 
            -> 뒤에 보이지 않는 것은 사라지게 하고 
            일정 거리를 두고 생성한다.

            보이지 않으면 끄게 한 후 앞에 자동 생성 하게 한다.

            보이지 않으면 실행되는 콜백함수를 게임매니저가 아닌 
            바닥과 오브젝트에 넣어야 함.

            맨처음에는 Start 문으로 기본적으로 배치( 랜덤 ) 를 한다.
            그 후 사라지는 오브젝트들로 인해 
            인비저블 콜백 함수가 실행된다.

            이 함수를 이용해서 계속해서 연쇄작용을 일으키면 될거같다. 

            생성 로직 
            -
            랜덤으로 숫자를 돌려서 나온 숫자를 토대로 생성될 오브젝트를 선정함
            

            선정된 오브젝트를 가지고 
            특정한 위치에 오브젝트를 킨다.





            알게 된 내용
            카메라에서 
            러프를 쓰는 이유는 카메라 이동에 딜레이를 주기 위해서임



            void OnBecameInvisible() //보이지 않으면 실행되는 콜백함수
    {
        isBecameInvisible = true;
    }

     * 
     * */



    public GameObject IDWObj;
    // 몬스터 프리팹을 할당할 변수 
    public GameObject [] monsterPrefabs;
    // 배경의 바닥 프리팹을 할당할 변수 
    public GameObject[] floorPrefabs;

    // 몬스터 풀링 준비 
    public List<GameObject> monsterPool = new List<GameObject>();
    // 몬스터 사이 거리 
    public float objDistance;

    // 게임이 끝나면 
    public bool isGameOver = true;
    // Obstruction의 스크립트에서 Invisible 콜백함수로 켜지는 불린값 
    public bool isBecameInvisible;
    public static GameManager instance = null;
    // 방해물 에넘문
    public enum MonsterName {idle ,AR , HG , RF , SG , MG, SMG , dangdang,parkG , Uroboros }
    // 몬스터 풀 총 크기 
    public int monsterLength;
    // 몬스터 인덱스를 랜덤하게 선정해서 넣을 변수 
    public int monsterRand;
    public Vector3 IDWNowVec;
   
    public Vector3 createVec;



    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    void Start () {

        // 생성 위치 초기화 
        createVec = new Vector3(30, 0.57f, 0);
        // 몬스터 리스트의 크기를 구함 
        monsterLength = monsterPrefabs.Length;
        // IDW의 현재 위치를 구함
        IDWNowVec.x = IDWObj.transform.position.x;
        //Debug.Log("monsterLength= " + monsterLength);
        
        
        // 오브젝트 풀링
        for (int j = 0; j < 3; j++) // 총 3배수로 만들기 위해서
        {
            for (int i = 0; i < monsterPrefabs.Length; i++) //monsterPrefabs.Length =8
            {
                GameObject monster = (GameObject)Instantiate(monsterPrefabs[i]); // 8개 * 3 
                monster.name = monster.name+":: "+j +" * "+i;
                monster.SetActive(false);
                monsterPool.Add(monster);
            }
        }
        // 생성 코루틴 시작 
        StartCoroutine(CreateMonster());

        // 램덤으로 생성할 로직 1000/8
        randomCreate(); // 현재 다른 것도 손봐야함 



    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public override string ToString()
    {
        return string.Format("현재 생성된 오브젝트 이름  :: {0} //  랜덤 값은   :: {1}  //  createVec.x( 생성될 위치 )  :: {2} // IDWNowVec.x( IDW 위치 ) :: {3} ", monsterPool[monsterRand].name , monsterRand , createVec.x , IDWNowVec.x);
    }

    //Obstructions의 IEnumerator PushObjectPool()로 생성됨  
    IEnumerator CreateMonster()
    {
        //게임 종료 시까지 무한 루프
        while (!isGameOver)
        {
            IDWNowVec.x = IDWObj.transform.position.x;

            if (createVec.x < IDWNowVec.x + 2000 && IDWNowVec.x - 500 < createVec.x  ) // 이 조건으로 IDW 의 앞 어디서부터 생성될지 그리고 뒤 부분 어디부터 회수할껀지 정함 
            {

                //Debug.Log(randomCreate());
                
                //monsterRand = Random.Range(0, monsterLength * 3); // 몬스터 리스트 크기 * 생성된 큐 *past

                int rand = Random.Range(0, 3); // 
                // 설명 
                /*배열 총 크기 = 8 * 3
                0  1  2   3  4  5  6  7     ...0
                8  9  10 11 12 13 14  15    ...1
                16 17 18 19 20 21 22  23    ...2      */  
                if (rand ==0 )
                {
                    rand = 0;
                }
                else if (rand == 1)
                {
                    rand = monsterLength;
                    
                }
                else if (rand ==2 )
                {
                    rand = monsterLength * 2;
                }

                int result = (rand + randomCreate()) ; // ex ) 0 + 5 , 8 +5  .16 +5
                //Debug.Log("rand  : " +rand+ "// randomCreate() "+ randomCreate() + "   // result  " + result);
                if (!monsterPool[result].activeSelf) // 안켜진거 
                {
                    monsterPool[result].transform.position = createVec;
                    monsterPool[result].SetActive(true);
                    createVec.x = createVec.x + 50;
                    
                    //Debug.Log(ToString()); // 
                }
            }
            yield return null;
        }
    }

  
    public int randomCreate()
    {
        int Total = Obstruction_Status.Total;
        if (GameBalancer.Girls_status[0].incidence +
            GameBalancer.Girls_status[1].incidence +
            GameBalancer.Girls_status[2].incidence +
            GameBalancer.Girls_status[3].incidence +
            GameBalancer.Girls_status[4].incidence +

            GameBalancer.Iron_status[0].incidence +
            GameBalancer.Iron_status[1].incidence +
            GameBalancer.Iron_status[2].incidence == Total) // 아직은 머리가 딸려서 확률 로직을 잘 못짰는데 생성률의 총합이 Total값과 똑같아야 한다.  //놀랍게도 위에있는 저것들은 조건식이다. 
        {

            
            int randomIncidence = Random.Range(0, Total); //
            int objAllcount = GameBalancer.Girls_status.Length + GameBalancer.Iron_status.Length; // 2개의 배열의 크기 합치기 //현재 8
            int A =0;
            int B = 0;


            // 철혈과 인형 스테이터스 배열을 합치는 작업 
            int result = 0; ;
            Obstruction_Status[] temp = new Obstruction_Status[objAllcount];                                                                // 만약 인형이 7개 철혈이 5개라면? 
            for (int i =0; i < objAllcount; i++)                                                                                            // 12개 
            {
                if (i < GameBalancer.Girls_status.Length) //0~4 까지 모두 Temp에 넣는다.                                                    //   만약 0~ 6이고
                {
                    temp[i] = GameBalancer.Girls_status[i];
                    
                }
                
                else if(i >= GameBalancer.Girls_status.Length) // 6 > 5//5 - 5 = 0 // 0이 두개라서 Iron_status.Length+2를 해주었고              // 7~ 12   7 - 7 = 0  // 재사용화 가능 확정 
                {
                    int tempInt = i - (GameBalancer.Iron_status.Length + 2);
                    
                    temp[i] = GameBalancer.Iron_status[tempInt];//GameBalancer.Iron_status[i - GameBalancer.Iron_status.Length + 2]; // 5 - 3+2 
                }
                //Debug.Log(" GameBalancer.Girls_status.Length "+GameBalancer.Girls_status.Length);
                //Debug.Log(" i : "+ i +" 배열의 숫자는 "+ temp[i].name_number);
            }


            for (int i = 0; i < objAllcount; i++)
            {
                A = B; 
                 B = A + temp[i].incidence;
                if (A < randomIncidence && randomIncidence < B)
                {
                    //Debug.Log(A + " < " + randomIncidence + " < " + B + "  따라서 name_number :  "+ temp[i].name_number);
                    result= temp[i].name_number;
                    break;
                }
                
            }
            return result;





        }
        // 총합이 같지 않을 떄 호출됨 
        else
        {
            Debug.Break();
            Debug.LogWarning("총합이 같지 않습니다. 총합을 확인해 주세요.");
            return -7272;
        }
        
    }
    // randomCreate() 끝! 


}
