
namespace DataCreation.Factory
{
    public abstract class FactoryBase<T>
    {
        public List<T> Items { get; set; }
        public abstract void Create();
    }
}
