using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Skill : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject Skiller;
    public GameObject bullet;
    public Transform bulletStartTr;
    public Transform SkillerCameraTr;
    public GameObject IDW;
    public AudioClip audioClip;
    // Use this for initialization
    void Start () {

        audioClip = GetComponent<AudioClip>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void startSkill()
    {
        StartCoroutine(onSkill());
    }

    public IEnumerator onSkill()
    {
        while (true)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, Skiller.transform.position, 0.5f);

            // 춘전이가 총을 쏨 
            Instantiate(bullet, bulletStartTr);
            SoundManager._instence.PlaySE(audioClip);                                       // 총알 사운드
                                                                                            // 탕! 효과가 있었으면 좋겠음    
                                                                                            // 총알을 따라서 카메라가 따라감       
            bullet.transform.position = Vector3.Lerp(bulletStartTr.position, IDW.transform.position, 0.5f);

            yield return null;
        }
        
    }

}
