using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
	GUISkin menuGui;

	int wood = 0;
	int stone = 0;
	int meat = 0;
	int fish = 0;
	int cookedFish = 0;

	bool showGui = false;

	void Update()
	{
		if( Input.GetKeyDown("i") )
		{
			showGui = true;
		}

		if( showGui == true )
		{
			Time.simeScale = 0; //freeze gameplay.
			GameObject.Find("Player").GetComponent<ThirsPersonController>().enabled = false;//disable player control.
			GameObject.Find("Main Camera").GetComponent<MOuseLook>().enabled = false;//disable camera control.
		}

		if( showGui == false )
		{
			Time.simeScale = 0; //unfreeze gameplay.
			GameObject.Find("Player").GetComponent<ThirsPersonController>().enabled = true;//disable player control.
			GameObject.Find("Main Camera").GetComponent<MOuseLook>().enabled = true;//disable camera control.
		}
	}

	void onGUI()
	{
		if( showGUI == true )
		{
		GUI.skin = menuSkin;
			GUI.BeginGroup( new Rect( Screen.width / 2- 150, Screen.height / 2 -150, 300, 300 )); //Find the screen width, divide it by 2..//then subtract 150 from it further.  Set the resolution to 300 x 300 pixels.
				GUI.Box( Rect( 0, 0, 300, 300 ), "Inventory");  

				
				//Resources
				GUI.Label( Rect( 10, 50, 50, 50, 50), "Wood" );//move x units across, move y units up, width, height.
				GUI.Box( Rect( 60, 50, 20, 20, "" + wood ));

				GUI.Label( Rect( 90, 50, 50, 50, 50), "Stone" );//move x units across, move y units up, width, height. increase 80 units
				GUI.Box( Rect( 130, 50, 20, 20, "" + stone ));//Increase 80 units

				

				//Empty holders

				GUI.Label( Rect( 250, 50, 50, 50, 50), "Meat" );//move x units across, move y units up, width, height. increase 80 units
				GUI.Box( Rect( 300, 50, 20, 20, "" + meat ));//Increase 80 units


				//Edibles
				GUI.Label( Rect( 170, 50, 50, 50, 50), "Cooked Fish" );
				GUI.Box( Rect( 210, 50, 20, 20, "" + fish ));
				
				if( GUI.Button( Rect( 100, 190, 20, 20 ), "" + "Eat Fish?"))
				{
					cookedFish--;
				}

				GUI.Label( Rect( 250, 50, 50, 50, 50), "Meat" );//move x units across, move y units up, width, height. increase 80 units
				GUI.Box( Rect( 300, 50, 20, 20, "" + meat ));//Increase 80 units

				GUI.EndGroup();

		}
	}
}	
