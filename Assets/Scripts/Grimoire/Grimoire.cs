namespace RPG.Combat
{
    public enum GrimoireOrder
    {
        First, Second
    }
    
    interface ISpell
    {
        float GetDamage();

        float GetAnimationDuration();

    }

    interface IInvetory
    {
        Grimoire GetGrimoire();
    }

    interface IGrimoire
    {
        Spell GetSpell(int i);
    }
    
    public class Inventory: IInvetory
    {
        public Grimoire GetGrimoire()
        {
            return new Grimoire();
        }
    }


    public class Spell: ISpell
    {
        public float GetDamage()
        {
            return 20f;
        }

        public float GetAnimationDuration()
        {
            return 1f;
        }
    }
    
    
    [UnityEngine.CreateAssetMenu(fileName = "Grimoire", menuName = "Grimoire/Create new Grimoire", order = 0)]
    public class Grimoire : UnityEngine.ScriptableObject, IGrimoire
    {
        public Spell GetSpell(int i)
        {
            return new Spell();
        }
    }
}