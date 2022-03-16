using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Vendor/Item")]
public class VendorItem : ScriptableObject
{
 public CMana manaItem;
 public CHealth healthItem;
 //public Card CardToSell;
 public int Cost;
}