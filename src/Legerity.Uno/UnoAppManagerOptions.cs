namespace Legerity.Uno
{
    /// <summary>
    /// Defines a model that represents configuration options for the <see cref="UnoAppManager"/>.
    /// </summary>
    public class UnoAppManagerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnoAppManagerOptions"/> class with a platform specific <see cref="Legerity.AppManagerOptions"/>.
        /// </summary>
        /// <param name="options">The platform specified <see cref="Legerity.AppManagerOptions"/>.</param>
        public UnoAppManagerOptions(AppManagerOptions options)
        {
            this.AppManagerOptions = options;
        }

        /// <summary>
        /// Gets the platform specific <see cref="Legerity.AppManagerOptions"/>.
        /// </summary>
        public AppManagerOptions AppManagerOptions { get; }
    }
}