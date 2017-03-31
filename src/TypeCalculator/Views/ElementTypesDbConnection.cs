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
            var elementTypes = ElementTypes.AllButNone;
            return !elementTypes.All(elementType => _database.GetAttributesFor(elementType).Updated);
        }

        public void UpdateStats()
        {
            addStrongAttacks();
            addWeakAttacks();
            addStrongDefense();
            addWeakDefense();
            addImmuneDefense();
            _database.UpdateTypesList(ElementTypes.Types);
            ElementTypes.Types = _database.GetTypesList();
        }

        private void addStrongAttacks()
        {
            add(StatType.StrongAttack, ElementTypes.Bug, ElementTypes.Dark, ElementTypes.Grass, ElementTypes.Psychic);
            add(StatType.StrongAttack, ElementTypes.Dark, ElementTypes.Ghost, ElementTypes.Psychic);
            add(StatType.StrongAttack, ElementTypes.Dragon, ElementTypes.Dragon);
            add(StatType.StrongAttack, ElementTypes.Electric, ElementTypes.Flying, ElementTypes.Water);
            add(StatType.StrongAttack, ElementTypes.Fairy, ElementTypes.Dark, ElementTypes.Dragon, ElementTypes.Fighting);
            add(StatType.StrongAttack, ElementTypes.Fighting, ElementTypes.Dark, ElementTypes.Ice, ElementTypes.Normal, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.StrongAttack, ElementTypes.Fire, ElementTypes.Grass, ElementTypes.Bug, ElementTypes.Ice, ElementTypes.Steel);
            add(StatType.StrongAttack, ElementTypes.Flying, ElementTypes.Bug, ElementTypes.Fighting, ElementTypes.Grass);
            add(StatType.StrongAttack, ElementTypes.Ghost, ElementTypes.Ghost, ElementTypes.Psychic);
            add(StatType.StrongAttack, ElementTypes.Grass, ElementTypes.Ground, ElementTypes.Rock, ElementTypes.Water);
            add(StatType.StrongAttack, ElementTypes.Ground, ElementTypes.Electric, ElementTypes.Fire, ElementTypes.Poison, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.StrongAttack, ElementTypes.Ice, ElementTypes.Dragon, ElementTypes.Flying, ElementTypes.Grass, ElementTypes.Ground);
            add(StatType.StrongAttack, ElementTypes.Poison, ElementTypes.Fairy, ElementTypes.Grass);
            add(StatType.StrongAttack, ElementTypes.Psychic, ElementTypes.Fighting, ElementTypes.Poison);
            add(StatType.StrongAttack, ElementTypes.Rock, ElementTypes.Bug, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Ice);
            add(StatType.StrongAttack, ElementTypes.Steel, ElementTypes.Fairy, ElementTypes.Ice, ElementTypes.Rock);
            add(StatType.StrongAttack, ElementTypes.Water, ElementTypes.Fire, ElementTypes.Ground, ElementTypes.Rock);
        }

        private void addWeakAttacks()
        {
            add(StatType.WeakAttack, ElementTypes.Bug, ElementTypes.Fairy, ElementTypes.Fighting, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Ghost, ElementTypes.Poison, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Dark, ElementTypes.Dark, ElementTypes.Fairy, ElementTypes.Fighting);
            add(StatType.WeakAttack, ElementTypes.Dragon, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Electric, ElementTypes.Dragon, ElementTypes.Electric, ElementTypes.Grass);
            add(StatType.WeakAttack, ElementTypes.Fairy, ElementTypes.Fire, ElementTypes.Poison, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Fighting, ElementTypes.Bug, ElementTypes.Fairy, ElementTypes.Flying, ElementTypes.Poison, ElementTypes.Psychic);
            add(StatType.WeakAttack, ElementTypes.Fire, ElementTypes.Dragon, ElementTypes.Fire, ElementTypes.Rock, ElementTypes.Water);
            add(StatType.WeakAttack, ElementTypes.Flying, ElementTypes.Electric, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Ghost, ElementTypes.Dark);
            add(StatType.WeakAttack, ElementTypes.Grass, ElementTypes.Bug, ElementTypes.Dragon, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Grass, ElementTypes.Poison, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Ground, ElementTypes.Bug, ElementTypes.Grass);
            add(StatType.WeakAttack, ElementTypes.Ice, ElementTypes.Fire, ElementTypes.Ice, ElementTypes.Steel, ElementTypes.Water);
            add(StatType.WeakAttack, ElementTypes.Normal, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Poison, ElementTypes.Ghost, ElementTypes.Ground, ElementTypes.Poison, ElementTypes.Rock);
            add(StatType.WeakAttack, ElementTypes.Psychic, ElementTypes.Psychic, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Rock, ElementTypes.Fighting, ElementTypes.Ground, ElementTypes.Steel);
            add(StatType.WeakAttack, ElementTypes.Steel, ElementTypes.Electric, ElementTypes.Fire, ElementTypes.Steel, ElementTypes.Water);
            add(StatType.WeakAttack, ElementTypes.Water, ElementTypes.Dragon, ElementTypes.Grass, ElementTypes.Water);
        }

        private void addStrongDefense()
        {
            add(StatType.StrongDefense, ElementTypes.Bug, ElementTypes.Fighting, ElementTypes.Grass, ElementTypes.Ground);
            add(StatType.StrongDefense, ElementTypes.Dark, ElementTypes.Dark, ElementTypes.Ghost);
            add(StatType.StrongDefense, ElementTypes.Dragon, ElementTypes.Electric, ElementTypes.Fire, ElementTypes.Grass, ElementTypes.Water);
            add(StatType.StrongDefense, ElementTypes.Electric, ElementTypes.Electric, ElementTypes.Flying, ElementTypes.Steel);
            add(StatType.StrongDefense, ElementTypes.Fairy, ElementTypes.Bug, ElementTypes.Dark, ElementTypes.Fighting);
            add(StatType.StrongDefense, ElementTypes.Fighting, ElementTypes.Bug, ElementTypes.Dark, ElementTypes.Rock);
            add(StatType.StrongDefense, ElementTypes.Fire, ElementTypes.Bug, ElementTypes.Fairy, ElementTypes.Fire, ElementTypes.Grass, ElementTypes.Ice, ElementTypes.Steel);
            add(StatType.StrongDefense, ElementTypes.Flying, ElementTypes.Bug, ElementTypes.Fighting, ElementTypes.Grass);
            add(StatType.StrongDefense, ElementTypes.Ghost, ElementTypes.Bug, ElementTypes.Poison);
            add(StatType.StrongDefense, ElementTypes.Grass, ElementTypes.Electric, ElementTypes.Grass, ElementTypes.Ground, ElementTypes.Water);
            add(StatType.StrongDefense, ElementTypes.Ground, ElementTypes.Poison, ElementTypes.Rock);
            add(StatType.StrongDefense, ElementTypes.Ice, ElementTypes.Ice);
            add(StatType.StrongDefense, ElementTypes.Poison, ElementTypes.Bug, ElementTypes.Fairy, ElementTypes.Fighting, ElementTypes.Grass, ElementTypes.Poison);
            add(StatType.StrongDefense, ElementTypes.Psychic, ElementTypes.Fighting, ElementTypes.Psychic);
            add(StatType.StrongDefense, ElementTypes.Rock, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Normal, ElementTypes.Poison);
            add(StatType.StrongDefense, ElementTypes.Steel, ElementTypes.Bug, ElementTypes.Dragon, ElementTypes.Fairy, ElementTypes.Flying, ElementTypes.Grass, ElementTypes.Ice, ElementTypes.Normal, ElementTypes.Psychic, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.StrongDefense, ElementTypes.Water, ElementTypes.Fire, ElementTypes.Ice, ElementTypes.Steel, ElementTypes.Water);
        }

        private void addWeakDefense()
        {
            add(StatType.WeakDefense, ElementTypes.Bug, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Rock);
            add(StatType.WeakDefense, ElementTypes.Dark, ElementTypes.Bug, ElementTypes.Fairy, ElementTypes.Fighting);
            add(StatType.WeakDefense, ElementTypes.Dragon, ElementTypes.Dragon, ElementTypes.Fairy, ElementTypes.Ice);
            add(StatType.WeakDefense, ElementTypes.Electric, ElementTypes.Ground);
            add(StatType.WeakDefense, ElementTypes.Fairy, ElementTypes.Poison, ElementTypes.Steel);
            add(StatType.WeakDefense, ElementTypes.Fighting, ElementTypes.Fairy, ElementTypes.Flying, ElementTypes.Psychic);
            add(StatType.WeakDefense, ElementTypes.Fire, ElementTypes.Ground, ElementTypes.Rock, ElementTypes.Water);
            add(StatType.WeakDefense, ElementTypes.Flying, ElementTypes.Electric, ElementTypes.Ice, ElementTypes.Rock);
            add(StatType.WeakDefense, ElementTypes.Ghost, ElementTypes.Dark, ElementTypes.Ghost);
            add(StatType.WeakDefense, ElementTypes.Grass, ElementTypes.Bug, ElementTypes.Fire, ElementTypes.Flying, ElementTypes.Ice, ElementTypes.Poison);
            add(StatType.WeakDefense, ElementTypes.Ground, ElementTypes.Grass, ElementTypes.Ice, ElementTypes.Water);
            add(StatType.WeakDefense, ElementTypes.Ice, ElementTypes.Fighting, ElementTypes.Fire, ElementTypes.Rock, ElementTypes.Steel);
            add(StatType.WeakDefense, ElementTypes.Normal, ElementTypes.Fighting);
            add(StatType.WeakDefense, ElementTypes.Poison, ElementTypes.Ground, ElementTypes.Psychic);
            add(StatType.WeakDefense, ElementTypes.Psychic, ElementTypes.Bug, ElementTypes.Dark, ElementTypes.Ghost);
            add(StatType.WeakDefense, ElementTypes.Rock, ElementTypes.Fighting, ElementTypes.Grass, ElementTypes.Ground, ElementTypes.Steel, ElementTypes.Water);
            add(StatType.WeakDefense, ElementTypes.Steel, ElementTypes.Fighting, ElementTypes.Fire, ElementTypes.Ground);
            add(StatType.WeakDefense, ElementTypes.Water, ElementTypes.Electric, ElementTypes.Grass);
        }

        private void addImmuneDefense()
        {
            add(StatType.ImmuneDefense, ElementTypes.Dark, ElementTypes.Psychic);
            add(StatType.ImmuneDefense, ElementTypes.Fairy, ElementTypes.Dragon);
            add(StatType.ImmuneDefense, ElementTypes.Flying, ElementTypes.Ground);
            add(StatType.ImmuneDefense, ElementTypes.Ghost, ElementTypes.Fighting, ElementTypes.Normal);
            add(StatType.ImmuneDefense, ElementTypes.Ground, ElementTypes.Electric);
            add(StatType.ImmuneDefense, ElementTypes.Normal, ElementTypes.Ghost);
            add(StatType.ImmuneDefense, ElementTypes.Steel, ElementTypes.Poison);
        }

        private void add(StatType statType, string elementType, params string[] elementTypes)
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
    }

    public enum StatType
    {
        StrongAttack,
        WeakAttack,
        StrongDefense,
        WeakDefense,
        ImmuneDefense
    }
}