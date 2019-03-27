using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    Animator mAnim;
	bool doForge = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doForge = true)
		{
            mAnim.SetTrigger("Forge");
        }
    }
}
