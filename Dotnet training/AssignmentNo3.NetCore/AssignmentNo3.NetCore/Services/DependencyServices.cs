namespace AssignmentNo3.NetCore.Services
{
    /// <summary>
    /// Implemented the method here which are defined on the or Inherit here
    /// </summary>
    public class DependencyServices:ITransient,IScoped, ISingleton
    {
        public Guid id;

        public DependencyServices() 
        {
            id = Guid.NewGuid();
        } 
        public Guid  getServicesId()
        {
            return id;
        }
    }
}
