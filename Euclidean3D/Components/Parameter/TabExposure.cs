using System;

using GH_Kernel = Grasshopper.Kernel;


namespace Basics.Components.Parameter
{
    /// <summary>
    /// Exposure of the current subcategory tabs.
    /// </summary>
    enum TabExposure
    {
        Manifold_0D = GH_Kernel.GH_Exposure.primary,
        Manifold_1D = GH_Kernel.GH_Exposure.secondary,
        Manifold_2D = GH_Kernel.GH_Exposure.tertiary,
        Manifold_3D = GH_Kernel.GH_Exposure.quarternary
    }
}