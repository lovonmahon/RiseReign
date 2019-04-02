using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    Animator mAnim;
	bool doHeal = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doHeal = true)
		{
            mAnim.SetTrigger("Heal");
        }
    }
}
