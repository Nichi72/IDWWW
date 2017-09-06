using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstructions : MonoBehaviour {
    bool isBecameInvisible;
    public GameObject obstructionObj;
    // Use this for initialization
    void Start () {
        
        StartCoroutine(PushObjectPool());
	}
	 
	// Update is called once per frame
	void Update () {
        //Debug.Log("!@@! 삭제된 이름 오브젝트 이름 ::  " + obstructionObj + " // 삭제된 오브젝트 위치 :: " + obstructionObj.transform.position.x + " 현재 IDW 위치  :: " + GameManager.instance.IDWNowVec.x);

    }
    IEnumerator PushObjectPool()
    {
        while (true)
        {
            if (this.gameObject.transform.position.x < GameManager.instance.IDWNowVec.x - 500)
            {
                //Debug.Log("!!!!!!! 삭제된 이름 오브젝트 이름 ::  " + obstructionObj + " // 삭제된 오브젝트 위치 :: " + this.gameObject.transform.position.x + " 현재 IDW 위치  :: " + GameManager.instance.IDWNowVec.x);
                this.gameObject.SetActive(false);
            }
           
            yield return null;
        }
    }



}
