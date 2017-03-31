using System.Collections.Generic;
using System.Linq;

namespace TypeCalculator.Core
{
    public class ElementTypes
    {
        public static readonly string None = "None";
        public static readonly string Bug = "Bug";
        public static readonly string Dark = "Dark";
        public static readonly string Dragon = "Dragon";
        public static readonly string Electric = "Electric";
        public static readonly string Fairy = "Fairy";
        public static readonly string Fighting = "Fighting";
        public static readonly string Fire = "Fire";
        public static readonly string Flying = "Flying";
        public static readonly string Ghost = "Ghost";
        public static readonly string Grass = "Grass";
        public static readonly string Ground = "Ground";
        public static readonly string Ice = "Ice";
        public static readonly string Normal = "Normal";
        public static readonly string Poison = "Poison";
        public static readonly string Psychic = "Psychic";
        public static readonly string Rock = "Rock";
        public static readonly string Steel = "Steel";
        public static readonly string Water = "Water";

        public static IList<string> AllButNone
        {
            get
            {
                return types.Where(x => !x.Equals(None)).ToList();
            }
        }

        public static IList<string> Types { get { return new List<string>(types); } set { types = value; } }

        private static IList<string> types = new List<string>
        {
            None,
            Bug,
            Dark,
            Dragon,
            Electric,
            Fairy,
            Fighting,
            Fire,
            Flying,
            Ghost,
            Grass,
            Ground,
            Ice,
            Normal,
            Poison,
            Psychic,
            Rock,
            Steel,
            Water
        };

        public static void AddType(string type)
        {
            if (!types.Contains(type))
            {
                types.Add(type);
            }
        }
    }
}