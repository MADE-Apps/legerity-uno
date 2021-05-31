namespace Legerity.Uno
{
    public class UnoAppManagerOptions
    {
        public UnoAppManagerOptions(AppManagerOptions options)
        {
            this.AppManagerOptions = options;
        }

        public AppManagerOptions AppManagerOptions { get; }
    }
}
