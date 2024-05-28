namespace AssignmentNo3.NetCore.Services
{
    /// <summary>
    /// reate the Interfaces Here
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
