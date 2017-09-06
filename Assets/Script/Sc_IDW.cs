using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_IDW : MonoBehaviour {
    
    public float x, y, z;
    public enum Action { idle ,flying1, flying2 , flying3 ,heat, c, d }; // 애니메이션에 쓸 친구들 
    public Action action = Action.idle;
    private Animator animator;
    public  GameObject IDWobj;
    
    
    // Use this for initialization
    void Start () {
        y = 500;
        StartCoroutine(physics());
        animator = this.gameObject.GetComponent<Animator>();
        IDWobj = this.gameObject;
        

    }
	
	// Update is called once per frame
	void Update () {
        
    }
    IEnumerator physics() // 중력값 
    {
        while (true)
        {
            GetComponent<Rigidbody>().AddForce(0, -y * Time.deltaTime, 0);
            yield return null;
        }
    }
    IEnumerator animations() 
    {
        while(true)
        {
            switch (action)
            {
                case Action.idle:
                    break;
                    
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Girls_AR":
                IDWobj.GetComponent<Rigidbody>().AddForce(750 , 500 ,0);
                Debug.Log("Girls_AR 호출은 됨");
                break;
            case "Girls_HG":
                IDWobj.GetComponent<Rigidbody>().AddForce(300, 150, 0);
                Debug.Log("Girls_HG 호출은 됨");
                break;
            case "Girls_MG":
                IDWobj.GetComponent<Rigidbody>().AddForce(2000, 1000, 0);
                Debug.Log("Girls_MG 호출은 됨");
                break;
            case "Girls_SG":
                IDWobj.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                Debug.Log("Girls_SG 호출은 됨");
                break;
            case "Girls_SMG":
                IDWobj.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                Debug.Log("Girls_SMG 호출은 됨");
                break;
            case "Iron_dangdang":
                IDWobj.GetComponent<Rigidbody>().AddForce(-700, -300, 0);
                Debug.Log("Iron_dangdang 호출은 됨");
                break;
            case "Iron_parkG":
                IDWobj.GetComponent<Rigidbody>().AddForce(-0, -300, 0);
                Debug.Log("Iron_parkG 호출은 됨");
                break;
            case "Iron_Uroboros":
                IDWobj.GetComponent<Rigidbody>().AddForce(-0, -700, 0);
                Debug.Log("Iron_Uroboros 호출은 됨");
                break;
            
        }
    }



}