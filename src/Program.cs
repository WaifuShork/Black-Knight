using System.Threading.Tasks;

namespace Blacknight
{
    // I moved everything to 'Blacknight.cs' so Main could stay clean
    internal static class Program
    {
        private static async Task Main() => await Blacknight.StartAsync();
    }
}