using System;

using GH_Kernel = Grasshopper.Kernel;

using Param_Euc = BRIDGES.McNeel.Grasshopper.Parameters.Geometry.Euclidean3D;


namespace Basics.Components.Parameter
{
    /// <inheritdoc cref="Param_Euc.Param_Polyline"/>
    public class Param_Polyline : Param_Euc.Param_Polyline
    {
        #region Constructors
        
        /// <summary>
        /// Creates a new instance of <see cref="Param_Polyline"/>.
        /// </summary>
        public Param_Polyline()
            : base(Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Parameter])
        {
            /* Do Nothing */
        }

        #endregion


        #region Override : Param_Polyline

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.Exposure"/>
        public override GH_Kernel.GH_Exposure Exposure => (GH_Kernel.GH_Exposure)TabExposure.Manifold_1D;

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ParameterAttributes(this);
        }

        #endregion
    }
}