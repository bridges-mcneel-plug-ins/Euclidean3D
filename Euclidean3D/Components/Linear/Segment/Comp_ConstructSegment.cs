using System;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Linear
{
    /// <summary>
    /// A grasshopper component to construct a point from its start and end points.
    /// </summary>
    public class Comp_ConstructSegment : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructSegment"/> class.
        /// </summary>
        public Comp_ConstructSegment()
          : base("Construct Segment", "Segment",
              "Construct a segment from its start and end points.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Linear])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Start Point", "S", "Start point of the segment.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddParameter(new Param.Param_Point(), "End Point", "E", "End point of the segment.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Segment(), "Segment", "S", "Segment from the start and end points.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            Euc3D.Point start = new Euc3D.Point(0d, 0d, 0d);
            Euc3D.Point end = new Euc3D.Point(0d, 0d, 0d);


            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref start)) { return; }
            if (!DA.GetData(1, ref end)) { return; }


            /******************** Core ********************/

            Euc3D.Segment segment = new Euc3D.Segment(start, end);

            /******************** Set Output ********************/
            DA.SetData(0, segment);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{405C4098-BC38-4D26-93AF-F37149377740}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Segment; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
