namespace BrokerMVC
{
    internal class AutofacDependencyResolver
    {
        private object container;

        public AutofacDependencyResolver(object container)
        {
            this.container = container;
        }
    }
}