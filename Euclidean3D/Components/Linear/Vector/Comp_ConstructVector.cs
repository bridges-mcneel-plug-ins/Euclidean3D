using System;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Linear
{
    /// <summary>
    /// A grasshopper component to construct a vector from its coordinates.
    /// </summary>
    public class Comp_ConstructVector : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructVector"/> class.
        /// </summary>
        public Comp_ConstructVector()
          : base("Construct Vector", "Vector",
              "Construct a vector from its coordinates.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Linear])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("First Coordinate", "X", "First coordinate of the vector.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddNumberParameter("Second Coordinate", "Y", "Second coordinate of the vector.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddNumberParameter("Third Coordinate", "Z", "Third coordinate of the vector.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Vector(), "Vector", "V", "Vector with the given coordinates.", GH_Kernel.GH_ParamAccess.item);
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

            Euc3D.Vector vector = new Euc3D.Vector(x, y, z);

            /******************** Set Output ********************/
            DA.SetData(0, vector);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{C0BBEDE6-5F4E-41CC-B9E4-12E11DDF876D}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Vector; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
