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
            addStrongAttacks();
            addWeakAttacks();
            addStrongDefense();
            addWeakDefense();
            addImmuneDefense();
        }

        private void addStrongAttacks()
        {
            add(StatType.StrongAttack, ElementType.Bug, ElementType.Dark, ElementType.Grass, ElementType.Psychic);
            add(StatType.StrongAttack, ElementType.Dark, ElementType.Ghost, ElementType.Psychic);
            add(StatType.StrongAttack, ElementType.Dragon, ElementType.Dragon);
            add(StatType.StrongAttack, ElementType.Electric, ElementType.Flying, ElementType.Water);
            add(StatType.StrongAttack, ElementType.Fairy, ElementType.Dark, ElementType.Dragon, ElementType.Fighting);
            add(StatType.StrongAttack, ElementType.Fighting, ElementType.Dark, ElementType.Ice, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            add(StatType.StrongAttack, ElementType.Fire, ElementType.Grass, ElementType.Bug, ElementType.Ice, ElementType.Steel);
            add(StatType.StrongAttack, ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            add(StatType.StrongAttack, ElementType.Ghost, ElementType.Ghost, ElementType.Psychic);
            add(StatType.StrongAttack, ElementType.Grass, ElementType.Ground, ElementType.Rock, ElementType.Water);
            add(StatType.StrongAttack, ElementType.Ground, ElementType.Electric, ElementType.Fire, ElementType.Poison, ElementType.Rock, ElementType.Steel);
            add(StatType.StrongAttack, ElementType.Ice, ElementType.Dragon, ElementType.Flying, ElementType.Grass, ElementType.Ground);
            add(StatType.StrongAttack, ElementType.Poison, ElementType.Fairy, ElementType.Grass);
            add(StatType.StrongAttack, ElementType.Psychic, ElementType.Fighting, ElementType.Poison);
            add(StatType.StrongAttack, ElementType.Rock, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice);
            add(StatType.StrongAttack, ElementType.Steel, ElementType.Fairy, ElementType.Ice, ElementType.Rock);
            add(StatType.StrongAttack, ElementType.Water, ElementType.Fire, ElementType.Ground, ElementType.Rock);
        }

        private void addWeakAttacks()
        {
            add(StatType.WeakAttack, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Fire, ElementType.Flying, ElementType.Ghost, ElementType.Poison, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Dark, ElementType.Dark, ElementType.Fairy, ElementType.Fighting);
            add(StatType.WeakAttack, ElementType.Dragon, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Electric, ElementType.Dragon, ElementType.Electric, ElementType.Grass);
            add(StatType.WeakAttack, ElementType.Fairy, ElementType.Fire, ElementType.Poison, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Fighting, ElementType.Bug, ElementType.Fairy, ElementType.Flying, ElementType.Poison, ElementType.Psychic);
            add(StatType.WeakAttack, ElementType.Fire, ElementType.Dragon, ElementType.Fire, ElementType.Rock, ElementType.Water);
            add(StatType.WeakAttack, ElementType.Flying, ElementType.Electric, ElementType.Rock, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Ghost, ElementType.Dark);
            add(StatType.WeakAttack, ElementType.Grass, ElementType.Bug, ElementType.Dragon, ElementType.Fire, ElementType.Flying, ElementType.Grass, ElementType.Poison, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Ground, ElementType.Bug, ElementType.Grass);
            add(StatType.WeakAttack, ElementType.Ice, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
            add(StatType.WeakAttack, ElementType.Normal, ElementType.Rock, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Poison, ElementType.Ghost, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            add(StatType.WeakAttack, ElementType.Psychic, ElementType.Psychic, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Rock, ElementType.Fighting, ElementType.Ground, ElementType.Steel);
            add(StatType.WeakAttack, ElementType.Steel, ElementType.Electric, ElementType.Fire, ElementType.Steel, ElementType.Water);
            add(StatType.WeakAttack, ElementType.Water, ElementType.Dragon, ElementType.Grass, ElementType.Water);
        }

        private void addStrongDefense()
        {
            add(StatType.StrongDefense, ElementType.Bug, ElementType.Fighting, ElementType.Grass, ElementType.Ground);
            add(StatType.StrongDefense, ElementType.Dark, ElementType.Dark, ElementType.Ghost);
            add(StatType.StrongDefense, ElementType.Dragon, ElementType.Electric, ElementType.Fire, ElementType.Grass, ElementType.Water);
            add(StatType.StrongDefense, ElementType.Electric, ElementType.Electric, ElementType.Flying, ElementType.Steel);
            add(StatType.StrongDefense, ElementType.Fairy, ElementType.Bug, ElementType.Dark, ElementType.Fighting);
            add(StatType.StrongDefense, ElementType.Fighting, ElementType.Bug, ElementType.Dark, ElementType.Rock);
            add(StatType.StrongDefense, ElementType.Fire, ElementType.Bug, ElementType.Fairy, ElementType.Fire, ElementType.Grass, ElementType.Ice, ElementType.Steel);
            add(StatType.StrongDefense, ElementType.Flying, ElementType.Bug, ElementType.Fighting, ElementType.Grass);
            add(StatType.StrongDefense, ElementType.Ghost, ElementType.Bug, ElementType.Poison);
            add(StatType.StrongDefense, ElementType.Grass, ElementType.Electric, ElementType.Grass, ElementType.Ground, ElementType.Water);
            add(StatType.StrongDefense, ElementType.Ground, ElementType.Poison, ElementType.Rock);
            add(StatType.StrongDefense, ElementType.Ice, ElementType.Ice);
            add(StatType.StrongDefense, ElementType.Poison, ElementType.Bug, ElementType.Fairy, ElementType.Fighting, ElementType.Grass, ElementType.Poison);
            add(StatType.StrongDefense, ElementType.Psychic, ElementType.Fighting, ElementType.Psychic);
            add(StatType.StrongDefense, ElementType.Rock, ElementType.Fire, ElementType.Flying, ElementType.Normal, ElementType.Poison);
            add(StatType.StrongDefense, ElementType.Steel, ElementType.Bug, ElementType.Dragon, ElementType.Fairy, ElementType.Flying, ElementType.Grass, ElementType.Ice, ElementType.Normal, ElementType.Psychic, ElementType.Rock, ElementType.Steel);
            add(StatType.StrongDefense, ElementType.Water, ElementType.Fire, ElementType.Ice, ElementType.Steel, ElementType.Water);
        }

        private void addWeakDefense()
        {
            add(StatType.WeakDefense, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Rock);
            add(StatType.WeakDefense, ElementType.Dark, ElementType.Bug, ElementType.Fairy, ElementType.Fighting);
            add(StatType.WeakDefense, ElementType.Dragon, ElementType.Dragon, ElementType.Fairy, ElementType.Ice);
            add(StatType.WeakDefense, ElementType.Electric, ElementType.Ground);
            add(StatType.WeakDefense, ElementType.Fairy, ElementType.Poison, ElementType.Steel);
            add(StatType.WeakDefense, ElementType.Fighting, ElementType.Fairy, ElementType.Flying, ElementType.Psychic);
            add(StatType.WeakDefense, ElementType.Fire, ElementType.Ground, ElementType.Rock, ElementType.Water);
            add(StatType.WeakDefense, ElementType.Flying, ElementType.Electric, ElementType.Ice, ElementType.Rock);
            add(StatType.WeakDefense, ElementType.Ghost, ElementType.Dark, ElementType.Ghost);
            add(StatType.WeakDefense, ElementType.Grass, ElementType.Bug, ElementType.Fire, ElementType.Flying, ElementType.Ice, ElementType.Poison);
            add(StatType.WeakDefense, ElementType.Ground, ElementType.Grass, ElementType.Ice, ElementType.Water);
            add(StatType.WeakDefense, ElementType.Ice, ElementType.Fighting, ElementType.Fire, ElementType.Rock, ElementType.Steel);
            add(StatType.WeakDefense, ElementType.Normal, ElementType.Fighting);
            add(StatType.WeakDefense, ElementType.Poison, ElementType.Ground, ElementType.Psychic);
            add(StatType.WeakDefense, ElementType.Psychic, ElementType.Bug, ElementType.Dark, ElementType.Ghost);
            add(StatType.WeakDefense, ElementType.Rock, ElementType.Fighting, ElementType.Grass, ElementType.Ground, ElementType.Steel, ElementType.Water);
            add(StatType.WeakDefense, ElementType.Steel, ElementType.Fighting, ElementType.Fire, ElementType.Ground);
            add(StatType.WeakDefense, ElementType.Water, ElementType.Electric, ElementType.Grass);
        }

        private void addImmuneDefense()
        {
            add(StatType.ImmuneDefense, ElementType.Dark, ElementType.Psychic);
            add(StatType.ImmuneDefense, ElementType.Fairy, ElementType.Dragon);
            add(StatType.ImmuneDefense, ElementType.Flying, ElementType.Ground);
            add(StatType.ImmuneDefense, ElementType.Ghost, ElementType.Fighting, ElementType.Normal);
            add(StatType.ImmuneDefense, ElementType.Ground, ElementType.Electric);
            add(StatType.ImmuneDefense, ElementType.Normal, ElementType.Ghost);
            add(StatType.ImmuneDefense, ElementType.Steel, ElementType.Poison);
        }

        private void add(StatType statType, ElementType elementType, params ElementType[] elementTypes)
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