using System;

using GH_Kernel = Grasshopper.Kernel;

using Param_Euc = BRIDGES.McNeel.Grasshopper.Parameters.Geometry.Euclidean3D;


namespace Basics.Components.Parameter
{
    /// <inheritdoc cref="Param_Euc.Param_Point"/>
    public class Param_Point : Param_Euc.Param_Point
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="Param_Point"/>.
        /// </summary>
        public Param_Point()
            : base(Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Parameter])
        {
            /* Do Nothing */
        }

        #endregion


        #region Override : Param_Point

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.Exposure"/>
        public override GH_Kernel.GH_Exposure Exposure => (GH_Kernel.GH_Exposure)TabExposure.Manifold_0D;

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ParameterAttributes(this);
        }

        #endregion
    }
}
