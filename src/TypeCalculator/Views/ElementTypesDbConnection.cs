using System;
using System.Linq;
using TypeCalculator.Core;

namespace TypeCalculator.Views
{
    public interface IElementTypesDbConnection
    {
        bool ShouldUpdateStats();
        void UpdateStats();
    }

    public class ElementTypesDbConnection : IElementTypesDbConnection
    {
        private readonly ITypeCalculatorDatabase _database;

        public ElementTypesDbConnection(ITypeCalculatorDatabase database)
        {
            _database = database;
        }

        public bool ShouldUpdateStats()
        {
            var elementTypes = ((ElementType[]) Enum.GetValues(typeof (ElementType))).Where(x => x != ElementType.None);
            return !elementTypes.All(elementType => _database.GetAttributesFor(elementType).Updated);
        }

        public void UpdateStats()
        {
            AddStrongAttacks();
            AddWeakAttacks();
            AddStrongDefense();
            AddWeakDefense();
            AddImmuneDefense();
        }

        private void AddStrongAttacks()
        {
            Add(StatType.StrongAttack, ElementType.Bug, ElementType.Dark, ElementType.Grass, ElementType.Psychic);
            Add(StatType.StrongAttack, ElementType.Dark, ElementType.Ghost, ElementType.Psychic);
            Add(StatType.StrongAttack, ElementType.Dragon, ElementType.Dragon);
            Add(StatType.StrongAttack, ElementType.Electric, ElementType.Flying, ElementType.Water);
            Add(StatType.StrongAttack, ElementType.Fairy, ElementType.Dark, ElementType.Dragon, ElementType.Fighting);
            Add(StatType.StrongAttack, ElementType.Fighting, ElementType.Dark, ElementType.Ice, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            Add(StatType.StrongAttack, ElementType.Fire, ElementType.Grass, ElementType.Bug, ElementType.Ice, ElementType.Steel);
            Add(StatType.StrongAttack, ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            Add(StatType.StrongAttack, ElementType.Ghost, ElementType.Ghost, ElementType.Psychic);
            Add(StatType.StrongAttack, ElementType.Grass, ElementType.Ground, ElementType.Rock, ElementType.Water);
            Add(StatType.StrongAttack, ElementType.Ground, ElementType.Electric, ElementType.Fire, ElementType.Poison, ElementType.Rock, ElementType.Steel);
            Add(StatType.StrongAttack, ElementType.Ice, ElementType.Dragon, ElementType.Flying, ElementType.Grass, ElementType.Ground);
            Add(StatType.StrongAttack, ElementType.Poison, ElementType.Fairy, ElementType.Grass);
            Add(StatType.StrongAttack, ElementType.Psychic, ElementType.Fighting, ElementType.Poison);
            Add(StatType.StrongAttack, ElementType.Rock, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice);
            Add(StatType.StrongAttack, ElementType.Steel, ElementType.Fairy, ElementType.Ice, ElementType.Rock);
            Add(StatType.StrongAttack, ElementType.Water, ElementType.Fire, ElementType.Ground, ElementType.Rock);
        }

        private void AddWeakAttacks()
        {
            Add(StatType.WeakAttack, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Fire, ElementType.Flying, ElementType.Ghost, ElementType.Poison, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Dark, ElementType.Dark, ElementType.Fairy, ElementType.Fighting);
            Add(StatType.WeakAttack, ElementType.Dragon, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Electric, ElementType.Dragon, ElementType.Electric, ElementType.Grass);
            Add(StatType.WeakAttack, ElementType.Fairy, ElementType.Fire, ElementType.Poison, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Fighting, ElementType.Bug, ElementType.Fairy, ElementType.Flying, ElementType.Poison, ElementType.Psychic);
            Add(StatType.WeakAttack, ElementType.Fire, ElementType.Dragon, ElementType.Fire, ElementType.Rock, ElementType.Water);
            Add(StatType.WeakAttack, ElementType.Flying, ElementType.Electric, ElementType.Rock, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Ghost, ElementType.Dark);
            Add(StatType.WeakAttack, ElementType.Grass, ElementType.Bug, ElementType.Dragon, ElementType.Fire, ElementType.Flying, ElementType.Grass, ElementType.Poison, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Ground, ElementType.Bug, ElementType.Grass);
            Add(StatType.WeakAttack, ElementType.Ice, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
            Add(StatType.WeakAttack, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Poison, ElementType.Ghost, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            Add(StatType.WeakAttack, ElementType.Psychic, ElementType.Psychic, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Rock, ElementType.Fighting, ElementType.Ground, ElementType.Steel);
            Add(StatType.WeakAttack, ElementType.Steel, ElementType.Electric, ElementType.Fire, ElementType.Steel, ElementType.Water);
            Add(StatType.WeakAttack, ElementType.Water, ElementType.Dragon, ElementType.Grass, ElementType.Water);
        }

        private void AddStrongDefense()
        {
            Add(StatType.StrongDefense, ElementType.Bug, ElementType.Fighting, ElementType.Grass, ElementType.Ground);
            Add(StatType.StrongDefense, ElementType.Dark, ElementType.Dark, ElementType.Ghost);
            Add(StatType.StrongDefense, ElementType.Dragon, ElementType.Electric, ElementType.Fire, ElementType.Grass, ElementType.Water);
            Add(StatType.StrongDefense, ElementType.Electric, ElementType.Electric, ElementType.Flying, ElementType.Steel);
            Add(StatType.StrongDefense, ElementType.Fairy, ElementType.Bug, ElementType.Dark, ElementType.Fighting);
            Add(StatType.StrongDefense, ElementType.Fighting, ElementType.Bug, ElementType.Dark, ElementType.Rock);
            Add(StatType.StrongDefense, ElementType.Fire, ElementType.Bug, ElementType.Fairy, ElementType.Fire, ElementType.Grass, ElementType.Ice, ElementType.Steel);
            Add(StatType.StrongDefense, ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            Add(StatType.StrongDefense, ElementType.Ghost, ElementType.Bug, ElementType.Poison);
            Add(StatType.StrongDefense, ElementType.Grass, ElementType.Electric, ElementType.Grass, ElementType.Ground, ElementType.Water);
            Add(StatType.StrongDefense, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            Add(StatType.StrongDefense, ElementType.Ice, ElementType.Ice);
            Add(StatType.StrongDefense, ElementType.Poison, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Grass, ElementType.Poison);
            Add(StatType.StrongDefense, ElementType.Psychic, ElementType.Fighting, ElementType.Psychic);
            Add(StatType.StrongDefense, ElementType.Rock, ElementType.Fire, ElementType.Flying, ElementType.Normal, ElementType.Poison);
            Add(StatType.StrongDefense, ElementType.Steel, ElementType.Bug, ElementType.Dragon, ElementType.Fairy, ElementType.Flying, ElementType.Grass, ElementType.Ice, ElementType.Normal, ElementType.Psychic, ElementType.Rock, ElementType.Steel);
            Add(StatType.StrongDefense, ElementType.Water, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
        }

        private void AddWeakDefense()
        {
            Add(StatType.WeakDefense, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Rock);
            Add(StatType.WeakDefense, ElementType.Dark, ElementType.Bug, ElementType.Fairy, ElementType.Fighting);
            Add(StatType.WeakDefense, ElementType.Dragon, ElementType.Dragon, ElementType.Fairy, ElementType.Ice);
            Add(StatType.WeakDefense, ElementType.Electric, ElementType.Ground);
            Add(StatType.WeakDefense, ElementType.Fairy, ElementType.Poison, ElementType.Steel);
            Add(StatType.WeakDefense, ElementType.Fighting, ElementType.Fairy, ElementType.Flying, ElementType.Psychic);
            Add(StatType.WeakDefense, ElementType.Fire, ElementType.Ground, ElementType.Rock, ElementType.Water);
            Add(StatType.WeakDefense, ElementType.Flying, ElementType.Electric, ElementType.Ice, ElementType.Rock);
            Add(StatType.WeakDefense, ElementType.Ghost, ElementType.Dark, ElementType.Ghost);
            Add(StatType.WeakDefense, ElementType.Grass, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice, ElementType.Poison);
            Add(StatType.WeakDefense, ElementType.Ground, ElementType.Grass, ElementType.Ice, ElementType.Water);
            Add(StatType.WeakDefense, ElementType.Ice, ElementType.Fighting, ElementType.Fire, ElementType.Rock, ElementType.Steel);
            Add(StatType.WeakDefense, ElementType.Normal, ElementType.Fighting);
            Add(StatType.WeakDefense, ElementType.Poison, ElementType.Ground, ElementType.Psychic);
            Add(StatType.WeakDefense, ElementType.Psychic, ElementType.Bug, ElementType.Dark, ElementType.Ghost);
            Add(StatType.WeakDefense, ElementType.Rock, ElementType.Fighting, ElementType.Grass, ElementType.Ground, ElementType.Steel, ElementType.Water);
            Add(StatType.WeakDefense, ElementType.Steel, ElementType.Fighting, ElementType.Fire, ElementType.Ground);
            Add(StatType.WeakDefense, ElementType.Water, ElementType.Electric, ElementType.Grass);
        }

        private void AddImmuneDefense()
        {
            Add(StatType.ImmuneDefense, ElementType.Dark, ElementType.Psychic);
            Add(StatType.ImmuneDefense, ElementType.Fairy, ElementType.Dragon);
            Add(StatType.ImmuneDefense, ElementType.Flying, ElementType.Ground);
            Add(StatType.ImmuneDefense, ElementType.Ghost, ElementType.Fighting, ElementType.Normal);
            Add(StatType.ImmuneDefense, ElementType.Ground, ElementType.Electric);
            Add(StatType.ImmuneDefense, ElementType.Normal, ElementType.Ghost);
            Add(StatType.ImmuneDefense, ElementType.Steel, ElementType.Poison);
        }

        private void Add(StatType statType, ElementType elementType, params ElementType[] elementTypes)
        {
            var attributes = _database.GetAttributesFor(elementType);

            switch (statType)
            {
                case StatType.StrongAttack:
                    attributes.SetStrongAttack(elementTypes);
                    break;
                case StatType.WeakAttack:
                    attributes.SetWeakAttack(elementTypes);
                    break;
                case StatType.StrongDefense:
                    attributes.SetStrongDefense(elementTypes);
                    break;
                case StatType.WeakDefense:
                    attributes.SetWeakDefense(elementTypes);
                    break;
                case StatType.ImmuneDefense:
                    attributes.SetImmuneDefense(elementTypes);
                    break;
                default:
                    throw new Exception("No Stat types found matching: " + statType);
            }
            _database.UpdateAttributes(attributes);
        }

        private enum StatType
        {
            StrongAttack,
            WeakAttack,
            StrongDefense,
            WeakDefense,
            ImmuneDefense
        }
    }
}