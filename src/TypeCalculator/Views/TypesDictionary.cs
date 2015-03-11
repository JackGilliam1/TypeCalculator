using System;
using System.Collections.Generic;
using System.Linq;
using TypeCalculator.Core;

namespace TypeCalculator.Views
{
    public interface ITypesDictionary
    {
        IList<ElementType> GetStrongAttack(ElementType type);
        IList<ElementType> GetWeakAttack(ElementType type);
        IList<ElementType> GetWeakDefense(ElementType type);
        IList<ElementType> GetImmuneDefense(ElementType type);
        IList<ElementType> GetStrongDefense(ElementType type);
        IList<ElementStats> GetStats();
    }

    public class TypesDictionary : ITypesDictionary
    {
        private IList<ElementStats> _elementStats;
        private readonly IDictionary<ElementType, IList<ElementType>> _strongAttack;
        private readonly IDictionary<ElementType, IList<ElementType>> _weakAttack;
        private readonly IDictionary<ElementType, IList<ElementType>> _immuneDefense; 
        private readonly IDictionary<ElementType, IList<ElementType>> _weakDefense;
        private readonly IDictionary<ElementType, IList<ElementType>> _strongDefense; 

        public TypesDictionary()
        {
            _strongAttack = new Dictionary<ElementType, IList<ElementType>>();
            _weakAttack = new Dictionary<ElementType, IList<ElementType>>();
            _weakDefense = new Dictionary<ElementType, IList<ElementType>>();
            _strongDefense = new Dictionary<ElementType, IList<ElementType>>();
            _immuneDefense = new Dictionary<ElementType, IList<ElementType>>();
            Setup();
        }

        public IList<ElementType> GetStrongAttack(ElementType type)
        {
            return GetFrom(_strongAttack, type);
        }

        public IList<ElementType> GetWeakDefense(ElementType type)
        {
            return GetFrom(_weakDefense, type);
        }

        public IList<ElementType> GetImmuneDefense(ElementType type)
        {
            return GetFrom(_immuneDefense, type);
        }

        public IList<ElementType> GetWeakAttack(ElementType type)
        {
            return GetFrom(_weakAttack, type);
        }

        public IList<ElementType> GetStrongDefense(ElementType type)
        {
            return GetFrom(_strongDefense, type);
        }

        public IList<ElementStats> GetStats()
        {
            if (_elementStats != null)
            {
                return _elementStats;
            }
            _elementStats = new List<ElementStats>();

            var elementTypes = ((ElementType[]) Enum.GetValues(typeof (ElementType)))
                .Where(x => !x.Equals(ElementType.None))
                .ToList();

            var tempDictionary = new Dictionary<ElementType, ElementStats>();

            elementTypes.Each(x => tempDictionary.Add(x, new ElementStats(x)));

            var strongDefenseMultiplier = new MultiplierStrength(0.5, "Weak");
            var weakDefenseMultiplier = new MultiplierStrength(2, "Strong");
            var immuneDefenseMultiplier = new MultiplierStrength(0, "Immune");
            var normalMultiplier = new MultiplierStrength(1, "");
            foreach (var elementType in elementTypes)
            {
                var strongDefenses = GetStrongDefense(elementType);
                var weakDefenses = GetWeakDefense(elementType);
                var immuneDefenses = GetImmuneDefense(elementType);
                foreach (var strongDefense in strongDefenses)
                {
                    tempDictionary[strongDefense].Stats.Add(new ElementStat(elementType, strongDefenseMultiplier));
                }

                foreach (var weakDefense in weakDefenses)
                {
                    tempDictionary[weakDefense].Stats.Add(new ElementStat(elementType, weakDefenseMultiplier));
                }

                foreach (var immuneDefense in immuneDefenses)
                {
                    tempDictionary[immuneDefense].Stats.Add(new ElementStat(elementType, immuneDefenseMultiplier));
                }

                foreach (var elementTypeTwo in elementTypes)
                {
                    var stats = tempDictionary[elementTypeTwo].Stats;
                    if (!stats.Any(x => x.ElementType.Equals(elementType.ToString())))
                    {
                        stats.Add(new ElementStat(elementType, normalMultiplier));
                    }
                }
            }

            return _elementStats = tempDictionary.Values.ToList();
        }

        private static IList<ElementType> GetFrom(IDictionary<ElementType, IList<ElementType>> typeDictionary, ElementType type)
        {
            if (!typeDictionary.ContainsKey(type))
            {
                return new List<ElementType>();
            }
            return typeDictionary[type];
        }

        private void Setup()
        {
            SetupStrongAttack();
            SetupWeakAttack();
            SetupWeakDefense();
            SetupImmuneDefense();
            SetupStrongDefense();
        }

        private void SetupStrongAttack()
        {
            _strongAttack.Add(ElementType.Bug, ElementType.Dark, ElementType.Grass, ElementType.Psychic);
            _strongAttack.Add(ElementType.Dark, ElementType.Ghost, ElementType.Psychic);
            _strongAttack.Add(ElementType.Dragon, ElementType.Dragon);
            _strongAttack.Add(ElementType.Electric, ElementType.Flying, ElementType.Water);
            _strongAttack.Add(ElementType.Fairy, ElementType.Dark, ElementType.Dragon, ElementType.Fighting);
            _strongAttack.Add(ElementType.Fighting, ElementType.Dark, ElementType.Ice, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            _strongAttack.Add(ElementType.Fire, ElementType.Grass, ElementType.Bug, ElementType.Ice, ElementType.Steel);
            _strongAttack.Add(ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            _strongAttack.Add(ElementType.Ghost, ElementType.Ghost, ElementType.Psychic);
            _strongAttack.Add(ElementType.Grass, ElementType.Ground, ElementType.Rock, ElementType.Water);
            _strongAttack.Add(ElementType.Ground, ElementType.Electric, ElementType.Fire, ElementType.Poison, ElementType.Rock, ElementType.Steel);
            _strongAttack.Add(ElementType.Ice, ElementType.Dragon, ElementType.Flying, ElementType.Grass, ElementType.Ground);
            _strongAttack.Add(ElementType.Poison, ElementType.Fairy, ElementType.Grass);
            _strongAttack.Add(ElementType.Psychic, ElementType.Fighting, ElementType.Poison);
            _strongAttack.Add(ElementType.Rock, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice);
            _strongAttack.Add(ElementType.Steel, ElementType.Fairy, ElementType.Ice, ElementType.Rock);
            _strongAttack.Add(ElementType.Water, ElementType.Fire, ElementType.Ground, ElementType.Rock);
        }

        private void SetupWeakAttack()
        {
            _weakAttack.Add(ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Fire, ElementType.Flying, ElementType.Ghost, ElementType.Poison, ElementType.Steel);
            _weakAttack.Add(ElementType.Dark, ElementType.Dark, ElementType.Fairy, ElementType.Fighting);
            _weakAttack.Add(ElementType.Dragon, ElementType.Steel);
            _weakAttack.Add(ElementType.Electric, ElementType.Dragon, ElementType.Electric, ElementType.Grass);
            _weakAttack.Add(ElementType.Fairy, ElementType.Fire, ElementType.Poison, ElementType.Steel);
            _weakAttack.Add(ElementType.Fighting, ElementType.Bug, ElementType.Fairy, ElementType.Flying, ElementType.Poison, ElementType.Psychic);
            _weakAttack.Add(ElementType.Fire, ElementType.Dragon, ElementType.Fire, ElementType.Rock, ElementType.Water);
            _weakAttack.Add(ElementType.Flying, ElementType.Electric, ElementType.Rock, ElementType.Steel);
            _weakAttack.Add(ElementType.Ghost, ElementType.Dark);
            _weakAttack.Add(ElementType.Grass, ElementType.Bug, ElementType.Dragon, ElementType.Fire, ElementType.Flying, ElementType.Grass, ElementType.Poison, ElementType.Steel);
            _weakAttack.Add(ElementType.Ground, ElementType.Bug, ElementType.Grass);
            _weakAttack.Add(ElementType.Ice, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
            _weakAttack.Add(ElementType.Normal, ElementType.Rock, ElementType.Steel);
            _weakAttack.Add(ElementType.Poison, ElementType.Ghost, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            _weakAttack.Add(ElementType.Psychic, ElementType.Psychic, ElementType.Steel);
            _weakAttack.Add(ElementType.Rock, ElementType.Fighting, ElementType.Ground, ElementType.Steel);
            _weakAttack.Add(ElementType.Steel, ElementType.Electric, ElementType.Fire, ElementType.Steel, ElementType.Water);
            _weakAttack.Add(ElementType.Water, ElementType.Dragon, ElementType.Grass, ElementType.Water);
        }

        private void SetupStrongDefense()
        {
            _strongDefense.Add(ElementType.Bug, ElementType.Fighting, ElementType.Grass, ElementType.Ground);
            _strongDefense.Add(ElementType.Dark, ElementType.Dark, ElementType.Ghost);
            _strongDefense.Add(ElementType.Dragon, ElementType.Electric, ElementType.Fire, ElementType.Grass, ElementType.Water);
            _strongDefense.Add(ElementType.Electric, ElementType.Electric, ElementType.Flying, ElementType.Steel);
            _strongDefense.Add(ElementType.Fairy, ElementType.Bug, ElementType.Dark, ElementType.Fighting);
            _strongDefense.Add(ElementType.Fighting, ElementType.Bug, ElementType.Dark, ElementType.Rock);
            _strongDefense.Add(ElementType.Fire, ElementType.Bug, ElementType.Fairy, ElementType.Fire, ElementType.Grass, ElementType.Ice, ElementType.Steel);
            _strongDefense.Add(ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            _strongDefense.Add(ElementType.Ghost, ElementType.Bug, ElementType.Poison);
            _strongDefense.Add(ElementType.Grass, ElementType.Electric, ElementType.Grass, ElementType.Ground, ElementType.Water);
            _strongDefense.Add(ElementType.Ground, ElementType.Poison, ElementType.Rock);
            _strongDefense.Add(ElementType.Ice, ElementType.Ice);
            _strongDefense.Add(ElementType.Poison, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Grass, ElementType.Poison);
            _strongDefense.Add(ElementType.Psychic, ElementType.Fighting, ElementType.Psychic);
            _strongDefense.Add(ElementType.Rock, ElementType.Fire, ElementType.Flying, ElementType.Normal, ElementType.Poison);
            _strongDefense.Add(ElementType.Steel, ElementType.Bug, ElementType.Dragon, ElementType.Fairy, ElementType.Flying, ElementType.Grass, ElementType.Ice, ElementType.Normal, ElementType.Psychic, ElementType.Rock, ElementType.Steel);
            _strongDefense.Add(ElementType.Water, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
        }

        private void SetupWeakDefense()
        {
            _weakDefense.Add(ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Rock);
            _weakDefense.Add(ElementType.Dark, ElementType.Bug, ElementType.Fairy, ElementType.Fighting);
            _weakDefense.Add(ElementType.Dragon, ElementType.Dragon, ElementType.Fairy, ElementType.Ice);
            _weakDefense.Add(ElementType.Electric, ElementType.Ground);
            _weakDefense.Add(ElementType.Fairy, ElementType.Poison, ElementType.Steel);
            _weakDefense.Add(ElementType.Fighting, ElementType.Fairy, ElementType.Flying, ElementType.Psychic);
            _weakDefense.Add(ElementType.Fire, ElementType.Ground, ElementType.Rock, ElementType.Water);
            _weakDefense.Add(ElementType.Flying, ElementType.Electric, ElementType.Ice, ElementType.Rock);
            _weakDefense.Add(ElementType.Ghost, ElementType.Dark, ElementType.Ghost);
            _weakDefense.Add(ElementType.Grass, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice, ElementType.Poison);
            _weakDefense.Add(ElementType.Ground, ElementType.Grass, ElementType.Ice, ElementType.Water);
            _weakDefense.Add(ElementType.Ice, ElementType.Fighting, ElementType.Fire, ElementType.Rock, ElementType.Steel);
            _weakDefense.Add(ElementType.Normal, ElementType.Fighting);
            _weakDefense.Add(ElementType.Poison, ElementType.Ground, ElementType.Psychic);
            _weakDefense.Add(ElementType.Psychic, ElementType.Bug, ElementType.Dark, ElementType.Ghost);
            _weakDefense.Add(ElementType.Rock, ElementType.Fighting, ElementType.Grass, ElementType.Ground, ElementType.Steel, ElementType.Water);
            _weakDefense.Add(ElementType.Steel, ElementType.Fighting, ElementType.Fire, ElementType.Ground);
            _weakDefense.Add(ElementType.Water, ElementType.Electric, ElementType.Grass);
        }

        private void SetupImmuneDefense()
        {
            _immuneDefense.Add(ElementType.Dark, ElementType.Psychic);
            _immuneDefense.Add(ElementType.Fairy, ElementType.Dragon);
            _immuneDefense.Add(ElementType.Flying, ElementType.Ground);
            _immuneDefense.Add(ElementType.Ghost, ElementType.Fighting, ElementType.Normal);
            _immuneDefense.Add(ElementType.Ground, ElementType.Electric);
            _immuneDefense.Add(ElementType.Normal, ElementType.Ghost);
            _immuneDefense.Add(ElementType.Steel, ElementType.Poison);
        }
    }

    public class MultiplierStrength
    {
        public double Multiplier { get; private set; }
        public string Strength { get; private set; }

        public MultiplierStrength(double multiplier, string strength)
        {
            Multiplier = multiplier;
            Strength = strength;
        }
    }
}