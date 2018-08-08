

namespace Odin.Data
{
    public interface IOdinContextFactory
    {

        /// <summary>
        ///     Creates a new Entity Framework context.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a new context.
        /// </returns>

        OdinContext CreateContext();
    }
}
