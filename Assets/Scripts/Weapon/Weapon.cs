using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create new Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private WeaponAffix _weaponAffix;
        [SerializeField] private Characteristics _characteristics;
        
        
    }
}