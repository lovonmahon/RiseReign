using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //code taken from https://www.grimoirehex.com/unity-3d-combo-animation/
 //Unity 3D – Combo System Animation Grimoire
 
public class ComboAttacks : MonoBehaviour {
       
    Animator animator;//You may not need an animator, but if so declare it here   
       
    int noOfClicks; //Determines Which Animation Will Play
    bool canClick; //Locks ability to click during animation event
     
    void Start()
    {     
        //Initialize appropriate components
        animator = GetComponent<Animator>();      
               
        noOfClicks = 0;
        canClick = true;
    }
         
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { ComboStarter(); }
    }
 
    void ComboStarter()
    {      
        if (canClick)           
        {           
            noOfClicks++;
        }
                
        if (noOfClicks == 1)
        {           
            animator.SetInteger("animation", 31);
        }          
    }
 
    public void ComboCheck() {
        
        canClick = false;
         
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Forward Slash 31") && noOfClicks == 1 )
        {//If the first animation is still playing and only 1 click has happened, return to idle
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Forward Slash 31") &&  noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo          
            animator.SetInteger("animation", 33);
            canClick = true;
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Low Slash 33") && noOfClicks == 2)
        {  //If the second animation is still playing and only 2 clicks have happened, return to idle         
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
       else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Low Slash 33") && noOfClicks >= 3)
        {  //If the second animation is still playing and at least 3 clicks have happened, continue the combo         
            animator.SetInteger("animation", 6);
            canClick = true;           
        }
       else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Spin Slash 6"))
        { //Since this is the third and last animation, return to idle          
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }      
    }
}
