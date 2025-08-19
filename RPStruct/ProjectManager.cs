using System;
using System.Threading.Tasks;

namespace RPStruct;


internal class ProjectMetadata
{
    public string Name;
    public ushort TileSize;
}

// Singleton
internal class ProjectManager
{
    private static ProjectManager _instance;
    public static ProjectManager Get
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectManager();
            }

            return _instance;
        }
    }

    public bool HasProject => Metadata != null;

    public ProjectMetadata Metadata;

    private ProjectManager() { }

}
