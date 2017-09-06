using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    // UI전체를 포함하는 Canvas 오브젝트를 담을 변수
    protected GameObject canvas;
    // 사운드매니저 스크립트
    public SoundManager soundManager;
    // 버튼 클릭 사운드
    public AudioClip buttonSE;
    // 버튼에서 연결되는 기능들을 모아놓은 클래스
    Function buttonFuntion;
    // 하나의 인자값을 나누어 저장할 String 배열
    string[] splitedMessage = new string[5];


    // Use this for initialization
    void Start() {
        canvas = GameObject.FindGameObjectWithTag("UI");
        //soundManager = GameObject.Find("SoundManagerObject").GetComponent<SoundManager>();
        soundManager = SoundManager._instence;
        buttonFuntion = new Function();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClick(string message)
    {
        //print("Object Name: " + this.gameObject.name);
        //print("buttonManager의 게임 오브젝트: " + this.gameObject.name);

        // 효과음
        soundManager.PlaySE(buttonSE);

        // 기능
        // 메시지 분할
        splitedMessage = message.Split(',');
        switch (splitedMessage[0])
        {
            case "ChangeScene": buttonFuntion.ChangeScene(splitedMessage[1]);
                break;
            case "ChangeMenu": this.transform.parent.gameObject.SetActive(false); buttonFuntion.ChangeMenu(canvas, splitedMessage[1]);
                break;
            case "Setting": buttonFuntion.Setting(soundManager, splitedMessage[1]);
                break;
            default: print("[0] 기능 인자값 오류"); break;
        }
    }

    /*
    void closeCanvas()
    {
        print("Object Name: " + thisGameObject.name);
        //this.transform.parent.gameObject.SetActive(false);
    }
    */

    class Function 
    {
        // 씬 변경
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // 메뉴 변경
        public void ChangeMenu(GameObject canvas, string openMenuName)
        {
            //print("UI Menu Name: " + closeMenuName);
            //메뉴 활성화
            //GameObject.Find(menuName).SetActive(true);
            canvas.transform.Find(openMenuName).gameObject.SetActive(true);

            // 현재 활성홛된 메뉴 비활성화
            // 오류사항 :: 부모 오브젝트의 탐색이 OnClick 메소드에 밖에 안 먹기 때 문에 현재 OnClick에서 닫아주고 있다.
            //base.closeCanvas();
            //canvas.transform.Find(closeMenuName).parent.gameObject.SetActive(false);
            //thisGameObject.transform.parent.gameObject.SetActive(false);
        }

        // 설정 관련
        public void Setting(SoundManager soundManager, string set)
        {
            switch (set)
            {
                case "BGM_ON": soundManager.BGM_On(); break;
                case "BGM_OFF": soundManager.BGM_Off(); break;
                case "SE_ON": soundManager.SE_On(); break;
                case "SE_OFF": soundManager.SE_Off(); break;
                case "Vibrate_ON": soundManager.Vibrate_On(); break;
                case "Vibrate_OFF": soundManager.Vibrate_Off(); break;
                default: print("[1] 설정 인자값 오류"); break;
            }
        }
    }
}
