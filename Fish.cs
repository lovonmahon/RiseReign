using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Animator mAnim;
	bool doFish = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doFish = true)
		{
            mAnim.SetTrigger("Fish");
        }
    }
}
