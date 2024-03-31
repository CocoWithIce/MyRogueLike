using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "ScriptableObjects/CharacterInfo", order = 1)]
public class CharacterInfo : ScriptableObject
{
    public CharacterStat Health;
    public CharacterStat EnergyShield;
    public CharacterStat Mana;

    public CharacterStat AttackDamage;
    public CharacterStat AttackSpeed;
    public CharacterStat SpellDamage;
    public CharacterStat CastSpeeed;

    public CharacterStat CriticalChance;
    public CharacterStat CriticalDamage;

    public CharacterStat EvadeChange;
    public CharacterStat BlockChange;

    public CharacterStat MovementSpeed;
    
    public CharacterStat Intelligence;
    public CharacterStat Strength;
    public CharacterStat Dexterity;
}
