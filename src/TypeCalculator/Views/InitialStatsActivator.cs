using System.Collections.Generic;
using Bottles;
using Bottles.Diagnostics;

namespace TypeCalculator.Views
{
    public class InitialStatsActivator : IActivator
    {
        private readonly IElementTypesDbConnection _connection;

        public InitialStatsActivator(IElementTypesDbConnection connection)
        {
            _connection = connection;
        }

        public void Activate(IEnumerable<IPackageInfo> packages, IPackageLog log)
        {
            if (_connection.ShouldUpdateStats())
            {
                _connection.UpdateStats();
            }
            else
            {
                _connection.UpdateTypesList();
            }
        }
    }
}