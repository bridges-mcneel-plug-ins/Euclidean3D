using System;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Point
{
    /// <summary>
    /// A grasshopper component to construct a point from its coordinates.
    /// </summary>
    public class Comp_ConstructPoint : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructPoint"/> class.
        /// </summary>
        public Comp_ConstructPoint()
          : base("Construct Point", "Point",
              "Construct a point from its coordinates.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Point])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("First Coordinate", "X", "First coordinate of the point.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddNumberParameter("Second Coordinate", "Y", "Second coordinate of the point.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddNumberParameter("Third Coordinate", "Z", "Third coordinate of the point.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Point", "P", "Point with the given coordinates.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            double x = 0d, y = 0d, z = 0d;


            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref x)) { return; }
            if (!DA.GetData(1, ref y)) { return; }
            if (!DA.GetData(2, ref z)) { return; }


            /******************** Core ********************/

            Euc3D.Point point = new Euc3D.Point(x, y, z);

            /******************** Set Output ********************/
            DA.SetData(0, point);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{72974243-8165-4FAB-ACD8-3DAB56AD9BD1}"); }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.Icon"/>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.Exposure"/>
        public override GH_Kernel.GH_Exposure Exposure
        {
            get { return (GH_Kernel.GH_Exposure)TabExposure.Point; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
