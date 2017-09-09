 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager _instence;
    //public AudioClip SE_buttonClick;

    // 사운드 상태
    enum State { NONE, IDLE, PLAYING, SILENT, ON, OFF };


    // 
    State BGMState;
    State SEState;
    State VibrateState;

    // 배경음 처리를 위한 오디오 소스
    //AudioSource Audio_BGM = new AudioSource();
    AudioSource Audio_BGM;
    // 효과음 처리를 위한 오디오 소스
    //AudioSource Audio_SE = new AudioSource();
    AudioSource Audio_SE;

    public void printy(string str)
    {
        print(str);
    }

    private void Awake()
    {
        // 싱글턴 방식의 객체 생성
        _instence = this;
        // 씬 전환시에도 오디오 매니저 객체가 사라지지 않도록 막음
        DontDestroyOnLoad(this);
        // 오디오 매니저 오브젝트에 컴포넌트를 추가시켜 연결
        Audio_BGM = this.gameObject.AddComponent<AudioSource>();
        Audio_SE = this.gameObject.AddComponent<AudioSource>();

        // 초기 상태를 대기 상태로 맞춤
        BGMState = State.IDLE;
        SEState = State.IDLE;
        VibrateState = State.ON;
    }

    // Use this for initialization
    void Start()
    {
        //Audio_BGM.loop = true; // loop 설정이 왜 안될까나..
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 배경음
    // 배경음 셋팅
    void setBGMclip(AudioClip clip)
    {
        Audio_BGM.Stop();
        Audio_BGM.clip = clip;
    }

    // 배경음 시작
    public void playBGM(AudioClip clip)
    {
        //print("작동");
        //print("BGM 상태: " + BGMState);
        //print("SE 상태: " + SEState);
        switch (BGMState)
        {
            // 배경 오디오 소스가 대기 상태일 경우
            case State.IDLE:
                setBGMclip(clip);
                Audio_BGM.Play();
                //Audio_BGM.PlayOneShot(clip);
                break;
            // 배경 오디오 소스가 다른 작업을 실행 중일 경우
            case State.PLAYING:
                setBGMclip(clip);
                Audio_BGM.Play();
                BGMState = State.PLAYING;
                break;
        }
    }

    // 배경음 중단
    public void stopBGM()
    {
        Audio_BGM.Stop();
        BGMState = State.IDLE;
    }

    // 배경음 off 상태로
    public void BGM_Off()
    {
        stopBGM();
        BGMState = State.SILENT;
    }

    // 배경음 on 상태로
    public void BGM_On()
    {
        BGMState = State.IDLE;
        if (Audio_BGM.clip != null)
            Audio_BGM.Play();
    }

    // 효과음
    public void PlaySE(AudioClip clip)
    {
        switch (SEState)
        {
            case State.IDLE:
                Audio_SE.PlayOneShot(clip);
                break;
        }
    }

    public void stopSE()
    {
        Audio_SE.Stop();
        //SEState = State.NONE;
        SEState = State.IDLE;
    }

    public void SE_Off()
    {
        stopSE();
        SEState = State.SILENT;
    }

    public void SE_On()
    {
        SEState = State.IDLE;
    }

    // 진동
    public void Vibrate_On()
    {
        VibrateState = State.ON;
    }

    public void Vibrate_Off()
    {
        VibrateState = State.OFF;
    }
}
