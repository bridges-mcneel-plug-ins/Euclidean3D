using System;

using GH_Kernel = Grasshopper.Kernel;


namespace Basics.Components.Serialisation
{
    /// <summary>
    /// Exposure of the current subcategory tabs.
    /// </summary>
    enum TabExposure
    {
        Serialise = GH_Kernel.GH_Exposure.primary,
        Deserialise = GH_Kernel.GH_Exposure.secondary
    }
}