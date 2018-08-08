using System.Data.Entity;

namespace Odin.Data
{
    public class OdinEntityConfiguration : DbConfiguration
    {

        public OdinEntityConfiguration()
        {
            AddInterceptor(new StringTrimmerInterceptor());
        }
    }
}
