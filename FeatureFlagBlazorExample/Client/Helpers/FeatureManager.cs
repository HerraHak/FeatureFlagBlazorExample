using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FeatureFlagBlazorExample.Client.Helpers
{

    public interface IFeatureManager
    {
        bool IsEnabled(string feature);
    }

    public class FeatureManager : IFeatureManager
    {
        private readonly IConfiguration _configuration;

        public FeatureManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsEnabled(string feature)
        {
            if (!string.IsNullOrEmpty(feature))
            {
                return  _configuration.GetValue<bool>($"FeatureManagement:{feature}");
            }
            return false;
        }
    }
}
