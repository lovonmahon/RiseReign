using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
   public List<GameObject> items = new List<GameObject>();

   public void AddItem(GameObject i)
   {
       items.Add(i);
   }

   public GameObject FindItemWithTag(string tag)
   {
       foreach(GameObject i in items)
       {
           if( i.tag == tag)
           {
               return i;
           }
       }
       return null;
   }

   public void RemoveItem(GameObject i)
   {
       //find index of the particular item
       int indexToRemove = -1;//start at the last position in the array.  It is faster doing so for arrays.
       foreach(GameObject g in items)
       {
           indexToRemove++; //increment until the item to remove is found.
           if(g == i) {
               {
                   break;
               }
           }
       }
       if(indexToRemove >= -1)//lists don't function well when items are removed from the middle, so start at the end.
       {
           items.RemoveAt(indexToRemove);
       }
   }
      


}
