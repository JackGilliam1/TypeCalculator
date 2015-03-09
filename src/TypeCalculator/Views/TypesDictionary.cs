﻿using System;
using System.Collections.Generic;
using System.Linq;
using TypeCalculator.Core;

namespace TypeCalculator.Views
{
    public class TypesDictionary : ITypesDictionary
    {
        private readonly IDictionary<ElementType, IList<ElementType>> StrongAttack;
        private readonly IDictionary<ElementType, IList<ElementType>> WeakAttack;
        private readonly IDictionary<ElementType, IList<ElementType>> ImmuneDefense; 
        private readonly IDictionary<ElementType, IList<ElementType>> WeakDefense;
        private readonly IDictionary<ElementType, IList<ElementType>> StrongDefense; 

        public TypesDictionary()
        {
            StrongAttack = new Dictionary<ElementType, IList<ElementType>>();
            WeakAttack = new Dictionary<ElementType, IList<ElementType>>();
            WeakDefense = new Dictionary<ElementType, IList<ElementType>>();
            StrongDefense = new Dictionary<ElementType, IList<ElementType>>();
            ImmuneDefense = new Dictionary<ElementType, IList<ElementType>>();
            Setup();
        }

        public IList<ElementType> GetStrongAttack(ElementType type)
        {
            return GetFrom(StrongAttack, type);
        }

        public IList<ElementType> GetWeakDefense(ElementType type)
        {
            return GetFrom(WeakDefense, type);
        }

        public IList<ElementType> GetImmuneDefense(ElementType type)
        {
            return GetFrom(ImmuneDefense, type);
        }

        public IList<ElementType> GetWeakAttack(ElementType type)
        {
            return GetFrom(WeakAttack, type);
        }

        public IList<ElementType> GetStrongDefense(ElementType type)
        {
            return GetFrom(StrongDefense, type);
        }

        public IDictionary<ElementType, IDictionary<ElementType, double>> GetStats()
        {
            IDictionary<ElementType, IDictionary<ElementType, double>> statsDictionary = new Dictionary<ElementType, IDictionary<ElementType, double>>();

            var elementTypes = ((ElementType[]) Enum.GetValues(typeof (ElementType))).Where(x => !x.Equals(ElementType.None)).ToList();

            elementTypes.Each(x => statsDictionary.Add(x, new Dictionary<ElementType, double>()));

            foreach (var elementType in elementTypes)
            {
                var strongDefenses = GetStrongDefense(elementType);
                var weakDefenses = GetWeakDefense(elementType);
                var immuneDefenses = GetImmuneDefense(elementType);
                foreach (var strongDefense in strongDefenses)
                {
                    statsDictionary[strongDefense].Add(elementType, 0.5);
                }

                foreach(var weakDefense in weakDefenses)
                {
                    statsDictionary[weakDefense].Add(elementType, 2);
                }

                foreach (var immuneDefense in immuneDefenses)
                {
                    statsDictionary[immuneDefense].Add(elementType, 0);
                }

                foreach (var elementTypeTwo in elementTypes)
                {
                    var dictionary = statsDictionary[elementTypeTwo];
                    if (!dictionary.ContainsKey(elementType))
                    {
                        dictionary.Add(elementType, 1);
                    }
                }
            }

            return statsDictionary;
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
            StrongAttack.Add(ElementType.Bug, ElementType.Dark, ElementType.Grass, ElementType.Psychic);
            StrongAttack.Add(ElementType.Dark, ElementType.Ghost, ElementType.Psychic);
            StrongAttack.Add(ElementType.Dragon, ElementType.Dragon);
            StrongAttack.Add(ElementType.Electric, ElementType.Flying, ElementType.Water);
            StrongAttack.Add(ElementType.Fairy, ElementType.Dark, ElementType.Dragon, ElementType.Fighting);
            StrongAttack.Add(ElementType.Fighting, ElementType.Dark, ElementType.Ice, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            StrongAttack.Add(ElementType.Fire, ElementType.Grass, ElementType.Bug, ElementType.Ice, ElementType.Steel);
            StrongAttack.Add(ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            StrongAttack.Add(ElementType.Ghost, ElementType.Ghost, ElementType.Psychic);
            StrongAttack.Add(ElementType.Grass, ElementType.Ground, ElementType.Rock, ElementType.Water);
            StrongAttack.Add(ElementType.Ground, ElementType.Electric, ElementType.Fire, ElementType.Poison, ElementType.Rock, ElementType.Steel);
            StrongAttack.Add(ElementType.Ice, ElementType.Dragon, ElementType.Flying, ElementType.Grass, ElementType.Ground);
            StrongAttack.Add(ElementType.Poison, ElementType.Fairy, ElementType.Grass);
            StrongAttack.Add(ElementType.Psychic, ElementType.Fighting, ElementType.Poison);
            StrongAttack.Add(ElementType.Rock, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice);
            StrongAttack.Add(ElementType.Steel, ElementType.Fairy, ElementType.Ice, ElementType.Rock);
            StrongAttack.Add(ElementType.Water, ElementType.Fire, ElementType.Ground, ElementType.Rock);
        }

        private void SetupWeakAttack()
        {
            WeakAttack.Add(ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Fire, ElementType.Flying, ElementType.Ghost, ElementType.Poison, ElementType.Steel);
            WeakAttack.Add(ElementType.Dark, ElementType.Dark, ElementType.Fairy, ElementType.Fighting);
            WeakAttack.Add(ElementType.Dragon, ElementType.Steel);
            WeakAttack.Add(ElementType.Electric, ElementType.Dragon, ElementType.Electric, ElementType.Grass);
            WeakAttack.Add(ElementType.Fairy, ElementType.Fire, ElementType.Poison, ElementType.Steel);
            WeakAttack.Add(ElementType.Fighting, ElementType.Bug, ElementType.Fairy, ElementType.Flying, ElementType.Poison, ElementType.Psychic);
            WeakAttack.Add(ElementType.Fire, ElementType.Dragon, ElementType.Fire, ElementType.Rock, ElementType.Water);
            WeakAttack.Add(ElementType.Flying, ElementType.Electric, ElementType.Rock, ElementType.Steel);
            WeakAttack.Add(ElementType.Ghost, ElementType.Dark);
            WeakAttack.Add(ElementType.Grass, ElementType.Bug, ElementType.Dragon, ElementType.Fire, ElementType.Flying, ElementType.Grass, ElementType.Poison, ElementType.Steel);
            WeakAttack.Add(ElementType.Ground, ElementType.Bug, ElementType.Grass);
            WeakAttack.Add(ElementType.Ice, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
            WeakAttack.Add(ElementType.Normal, ElementType.Rock, ElementType.Steel);
            WeakAttack.Add(ElementType.Poison, ElementType.Ghost, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            WeakAttack.Add(ElementType.Psychic, ElementType.Psychic, ElementType.Steel);
            WeakAttack.Add(ElementType.Rock, ElementType.Fighting, ElementType.Ground, ElementType.Steel);
            WeakAttack.Add(ElementType.Steel, ElementType.Electric, ElementType.Fire, ElementType.Steel, ElementType.Water);
            WeakAttack.Add(ElementType.Water, ElementType.Dragon, ElementType.Grass, ElementType.Water);
        }

        private void SetupStrongDefense()
        {
            StrongDefense.Add(ElementType.Bug, ElementType.Fighting, ElementType.Grass, ElementType.Ground);
            StrongDefense.Add(ElementType.Dark, ElementType.Dark, ElementType.Ghost);
            StrongDefense.Add(ElementType.Dragon, ElementType.Electric, ElementType.Fire, ElementType.Grass, ElementType.Water);
            StrongDefense.Add(ElementType.Electric, ElementType.Electric, ElementType.Flying, ElementType.Steel);
            StrongDefense.Add(ElementType.Fairy, ElementType.Bug, ElementType.Dark, ElementType.Fighting);
            StrongDefense.Add(ElementType.Fighting, ElementType.Bug, ElementType.Dark, ElementType.Rock);
            StrongDefense.Add(ElementType.Fire, ElementType.Bug, ElementType.Fairy, ElementType.Fire, ElementType.Grass, ElementType.Ice, ElementType.Steel);
            StrongDefense.Add(ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            StrongDefense.Add(ElementType.Ghost, ElementType.Bug, ElementType.Poison);
            StrongDefense.Add(ElementType.Grass, ElementType.Electric, ElementType.Grass, ElementType.Ground, ElementType.Water);
            StrongDefense.Add(ElementType.Ground, ElementType.Poison, ElementType.Rock);
            StrongDefense.Add(ElementType.Ice, ElementType.Ice);
            StrongDefense.Add(ElementType.Poison, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Grass, ElementType.Poison);
            StrongDefense.Add(ElementType.Psychic, ElementType.Fighting, ElementType.Psychic);
            StrongDefense.Add(ElementType.Rock, ElementType.Fire, ElementType.Flying, ElementType.Normal, ElementType.Poison);
            StrongDefense.Add(ElementType.Steel, ElementType.Bug, ElementType.Dragon, ElementType.Fairy, ElementType.Flying, ElementType.Grass, ElementType.Ice, ElementType.Normal, ElementType.Psychic, ElementType.Rock, ElementType.Steel);
            StrongDefense.Add(ElementType.Water, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
        }

        private void SetupWeakDefense()
        {
            WeakDefense.Add(ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Rock);
            WeakDefense.Add(ElementType.Dark, ElementType.Bug, ElementType.Fairy, ElementType.Fighting);
            WeakDefense.Add(ElementType.Dragon, ElementType.Dragon, ElementType.Fairy, ElementType.Ice);
            WeakDefense.Add(ElementType.Electric, ElementType.Ground);
            WeakDefense.Add(ElementType.Fairy, ElementType.Poison, ElementType.Steel);
            WeakDefense.Add(ElementType.Fighting, ElementType.Fairy, ElementType.Flying, ElementType.Psychic);
            WeakDefense.Add(ElementType.Fire, ElementType.Ground, ElementType.Rock, ElementType.Water);
            WeakDefense.Add(ElementType.Flying, ElementType.Electric, ElementType.Ice, ElementType.Rock);
            WeakDefense.Add(ElementType.Ghost, ElementType.Dark, ElementType.Ghost);
            WeakDefense.Add(ElementType.Grass, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice, ElementType.Poison);
            WeakDefense.Add(ElementType.Ground, ElementType.Grass, ElementType.Ice, ElementType.Water);
            WeakDefense.Add(ElementType.Ice, ElementType.Fighting, ElementType.Fire, ElementType.Rock, ElementType.Steel);
            WeakDefense.Add(ElementType.Normal, ElementType.Fighting);
            WeakDefense.Add(ElementType.Poison, ElementType.Ground, ElementType.Psychic);
            WeakDefense.Add(ElementType.Psychic, ElementType.Bug, ElementType.Dark, ElementType.Ghost);
            WeakDefense.Add(ElementType.Rock, ElementType.Fighting, ElementType.Grass, ElementType.Ground, ElementType.Steel, ElementType.Water);
            WeakDefense.Add(ElementType.Steel, ElementType.Fighting, ElementType.Fire, ElementType.Ground);
            WeakDefense.Add(ElementType.Water, ElementType.Electric, ElementType.Grass);
        }

        private void SetupImmuneDefense()
        {
            ImmuneDefense.Add(ElementType.Dark, ElementType.Psychic);
            ImmuneDefense.Add(ElementType.Fairy, ElementType.Dragon);
            ImmuneDefense.Add(ElementType.Flying, ElementType.Ground);
            ImmuneDefense.Add(ElementType.Ghost, ElementType.Fighting, ElementType.Normal);
            ImmuneDefense.Add(ElementType.Ground, ElementType.Electric);
            ImmuneDefense.Add(ElementType.Normal, ElementType.Ghost);
            ImmuneDefense.Add(ElementType.Steel, ElementType.Poison);
        }
    }

    public class ElementStats
    {
        public string ElementType { get; private set; }
        public IList<ElementStat> Stats { get; private set; }

        public ElementStats(string elementType)
        {
            ElementType = elementType;
            Stats = new List<ElementStat>();
        }
    }

    public class ElementStat
    {
        public string ElementType { get; private set; }
        public double Multiplier { get; private set; }

        public ElementStat(string elementType, double multiplier)
        {
            ElementType = elementType;
            Multiplier = multiplier;
        }
    }

    public interface ITypesDictionary
    {
        IList<ElementType> GetStrongAttack(ElementType type);
        IList<ElementType> GetWeakAttack(ElementType type);
        IList<ElementType> GetWeakDefense(ElementType type);
        IList<ElementType> GetImmuneDefense(ElementType type);
        IList<ElementType> GetStrongDefense(ElementType type);
        IDictionary<ElementType, IDictionary<ElementType, double>> GetStats();
    }
}