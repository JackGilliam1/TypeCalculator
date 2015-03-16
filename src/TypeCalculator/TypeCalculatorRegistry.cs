using Bottles;
using StructureMap.Configuration.DSL;
using TypeCalculator.Core;
using TypeCalculator.Views;
using TypeCalculator.Views.Home;

namespace TypeCalculator
{
	public class TypeCalculatorRegistry : Registry
	{
		public TypeCalculatorRegistry()
		{
			// make any StructureMap configuration here
			
            // Sets up the default "IFoo is Foo" naming convention
            // for auto-registration within this assembly
            Scan(x => x.AssemblyContainingType<HomeInputModel>());

		    For<IActivator>().Add<InitialStatsActivator>();
            For<ITypesDictionary>().Use<TypesDictionary>();
            ForSingletonOf<ITypeCalculatorDatabase>().Use<MongoDbDatabase>();
		    For<IElementTypesDbConnection>().Use<ElementTypesDbConnection>();
		}
	}
}