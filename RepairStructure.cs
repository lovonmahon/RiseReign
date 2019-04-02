using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStructure : MonoBehaviour
{
    Animator mAnim;
	bool noRepair = false;

    void Start()
    {
        
		mAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doRepair = true)
		{
            mAnim.SetTrigger("Repair");
        }
    }
}
