using System;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Linear
{
    /// <summary>
    /// A grasshopper component to construct a ray from its origin and axis.
    /// </summary>
    public class Comp_ConstructRay : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructRay"/> class.
        /// </summary>
        public Comp_ConstructRay()
          : base("Construct Ray", "Ray",
              "Construct a ray from its origin and axis.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Linear])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Origin", "O", "Origin of the ray.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddParameter(new Param.Param_Vector(), "Axis", "V", "Vector defining the direction of the ray.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Ray(), "Ray", "R", "Ray emiting from the origin, in the given direction.", GH_Kernel.GH_ParamAccess.item);
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

            Euc3D.Ray ray = new Euc3D.Ray(origin, axis);

            /******************** Set Output ********************/
            DA.SetData(0, ray);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{5158C30E-B804-4E92-BC99-DF77EC7349F8}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Ray; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
