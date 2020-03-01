using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
   public static Inventory instance;
   void Awake(){
       instance = this;
       if(instance != null){
           Debug.LogWarning("More Than one instance of inventory found");
           return;
       }
   }
   #endregion
   public int space = 3;
   public delegate void OnItemChanged();
   public OnItemChanged onItemChangedCallBack;
   public List<Item> items = new List<Item>();

   public bool Add(Item item){
       if(!item.isDefaultItem){
           if(items.Count >= space){
            Debug.Log("Not Enough Space");
            return false;
           }       
           items.Add(item); 
           if(onItemChangedCallBack != null){
                onItemChangedCallBack.Invoke();
           }
              
       }
    return true;          
   }
   public void Remove(Item item){
       items.Remove(item);
   }
}
