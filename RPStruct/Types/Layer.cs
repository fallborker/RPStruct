using System;

namespace RPStruct.Types;

internal class Layer
{
    public enum LayerType
    {
        IntLayer,
        TileLayer
    }


    public string Name;
    public int Depth;
}
