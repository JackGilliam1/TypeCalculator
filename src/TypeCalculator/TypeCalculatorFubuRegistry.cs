using FubuMVC.Core;
using FubuMVC.Spark;
using TypeCalculator.Core;
using TypeCalculator.Views.Home;

namespace TypeCalculator
{
	public class TypeCalculatorFubuRegistry : FubuRegistry
	{
		public TypeCalculatorFubuRegistry()
		{
            Routes.HomeIs<HomeInputModel>();
            AlterSettings<SparkEngineSettings>(x => x.PrecompileViews = false);
            AlterSettings<MongoDbSettings>(x => x.DatabaseName.ToString());
            AlterSettings<MartenDbSettings>(x => x.DatabaseName.ToString());
		    // Register any custom FubuMVC policies, inclusions, or 
		    // other FubuMVC configuration here
		    // Or leave as is to use the default conventions unchanged
		}
	}
}