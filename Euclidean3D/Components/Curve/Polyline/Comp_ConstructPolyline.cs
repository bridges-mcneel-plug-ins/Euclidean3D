using System;
using System.Collections.Generic;

using Euc3D = BRIDGES.Geometry.Euclidean3D;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Curve
{
    /// <summary>
    /// A grasshopper component to construct a polyline from its vertices.
    /// </summary>
    public class Comp_ConstructPolyline : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_ConstructPolyline"/> class.
        /// </summary>
        public Comp_ConstructPolyline()
          : base("Construct Polyline", "Polyline",
              "Construct a polyline from its vertices.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Curve])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Vertices", "V", "Points composing the polyline.", GH_Kernel.GH_ParamAccess.list);
            pManager.AddBooleanParameter("Is Closed ?", "B", "Evaluates whether the polyline should be closed or not.", GH_Kernel.GH_ParamAccess.item);

            pManager[1].Optional = true;
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Polyline(), "Polyline", "P", "Polyline.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            List<Euc3D.Point> vertices = new List<Euc3D.Point>();
            bool isClosed = false;


            /******************** Get Inputs ********************/
            if (!DA.GetDataList(0, vertices)) { return; }
            
            // Optional
            DA.GetData(1, ref isClosed);       


            /******************** Core ********************/

            Euc3D.Polyline polyline = new Euc3D.Polyline(vertices, isClosed); ;

            /******************** Set Output ********************/
            DA.SetData(0, polyline);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{BFFE3ACE-91B2-4C7A-8C8D-B769268BE81E}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Polyline; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
