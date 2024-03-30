using System;
using UnityEngine;

public class Equipment
{
    public Sprite Icon;
    public GameObject Prefab;
    public ParticleSystem Effect;

    public string Name;
    public Guid ID;
    public EquipmentType Type;
    public RarityType Rarity;
    public ArraySegment<Affixes>[] Affixes = new ArraySegment<Affixes>[2];
}