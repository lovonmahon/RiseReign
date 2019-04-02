using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneak : MonoBehaviour
{
    Animator mAnim;
	bool doSneak = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doSneak = true)
		{
            mAnim.SetTrigger("Sneak");
        }
    }
}
