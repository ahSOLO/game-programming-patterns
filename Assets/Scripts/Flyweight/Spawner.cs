using Unity.Entities;

public struct Spawner : IComponentData
{
    public Unity.Entities.Entity Prefab;
    public int Erows;
    public int Ecols;
}
