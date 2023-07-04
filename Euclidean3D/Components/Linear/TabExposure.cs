using System;

using GH_Kernel = Grasshopper.Kernel;


namespace Basics.Components.Linear
{
    /// <summary>
    /// Exposure of the current subcategory tabs.
    /// </summary>
    enum TabExposure
    {
        Vector = GH_Kernel.GH_Exposure.primary,
        Ray = GH_Kernel.GH_Exposure.secondary,
        Line = GH_Kernel.GH_Exposure.tertiary,
        Segment = GH_Kernel.GH_Exposure.quarternary
    }
}