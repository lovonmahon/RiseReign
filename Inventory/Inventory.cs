using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiseReign;

public class Inventory : MonoBehaviour {

	public int flourLevel = 5;
	public int breadLevel = 0;
	public int wheatLevel = 0;
	public int fishingRod = 0;
	public int Bakes = 0;
	public int RawFlour = 0;
	public int Meat = 0;
	public int Fish = 0;
	public int Herbs = 0;
	public int Berries = 0;
	public int Manure = 0;
	public int Hammer = 0;
	public int Planks = 0;
	public int Weapon = 0;
	public int Nails = 0;
	public int Coins = 0;
	public int Trap = 0;
	public int CaughtAnimal = 0;
	public int cocoaBalls = 0;
	public int CocoaTea = 0;
	public int drawOffset = 0;
	public string name = "";
	
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0 + drawOffset, 100, 100), "" + name);
		GUI.Label(new Rect(10, 20 + drawOffset, 100, 20), "Flour: " + flourLevel);
		GUI.Label(new Rect(10, 35 + drawOffset, 100, 20), "Bread: " + breadLevel);
		GUI.Label(new Rect(10, 50 + drawOffset, 100, 20), "Wheat: " + wheatLevel);
	}
}
