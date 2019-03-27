using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    Animator mAnim;
	bool noWeapon = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(noWeapon = true)
		{
            mAnim.SetTrigger("Kick");
        }
    }
}
