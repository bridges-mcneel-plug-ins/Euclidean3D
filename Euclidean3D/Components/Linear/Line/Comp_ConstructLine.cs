using System;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Linear
{
    /// <summary>
    /// A grasshopper component to construct a line from its origin and axis.
    /// </summary>
    public class Comp_ConstructLine : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructLine"/> class.
        /// </summary>
        public Comp_ConstructLine()
          : base("Construct Line", "Line",
              "Construct a line from its origin and axis.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Linear])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Origin", "O", "Origin of the line.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddParameter(new Param.Param_Vector(), "Axis", "V", "Vector defining the direction of the line.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Line(), "Line", "L", "Line placed at the origin, align with the given direction.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            Euc3D.Point origin = new Euc3D.Point(0d, 0d, 0d);
            Euc3D.Vector axis = new Euc3D.Vector(0d, 0d, 0d);


            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref origin)) { return; }
            if (!DA.GetData(1, ref axis)) { return; }


            /******************** Core ********************/

            Euc3D.Line line = new Euc3D.Line(origin, axis);

            /******************** Set Output ********************/
            DA.SetData(0, line);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{FD94BAF2-4531-4561-8F4A-8CECA058AA51}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Line; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
