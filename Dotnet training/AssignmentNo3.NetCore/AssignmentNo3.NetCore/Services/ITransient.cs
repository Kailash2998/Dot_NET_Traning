namespace AssignmentNo3.NetCore.Services
{
    /// <summary>
    /// Create the Interfaces Here
    /// </summary>
    public interface ITransient
    {
        Guid getServicesId();
    }
    public interface IScoped
    {
        Guid getServicesId();
    }
    public interface ISingleton
    {
        Guid getServicesId();
    }
}
