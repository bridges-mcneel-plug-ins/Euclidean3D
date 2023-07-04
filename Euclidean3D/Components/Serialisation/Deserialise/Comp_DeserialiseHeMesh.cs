using System;

using Ser = BRIDGES.Serialisation;
using Euc3D = BRIDGES.Geometry.Euclidean3D;
using He = BRIDGES.DataStructures.PolyhedralMeshes.HalfedgeMesh;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Serialisation.Deserialise
{
    /// <summary>
    /// A grasshopper component to deserialise a halfedge mesh.
    /// </summary>
    public class Comp_DeserialiseHeMesh : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_DeserialiseHeMesh"/> class.
        /// </summary>
        public Comp_DeserialiseHeMesh()
          : base("Deserialise HeMesh", "Des. HeMesh",
              "Deserialises a halfedge mesh from formatted text.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Serialisation])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Formatted Text", "T", "Text representation of the halfedge mesh.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddIntegerParameter("File Format", "F", "File format for the serialisation of the halfedge mesh.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_HeMesh(), "Halfedge Mesh", "HeM", "Halfedge mesh to serialise.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            string text = "";
            int formatIndex = 0;


            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref text)) { return; }
            if (!DA.GetData(1, ref formatIndex)) { return; }


            /******************** Core ********************/

            Ser.PolyhedralMeshSerialisationFormat format = (Ser.PolyhedralMeshSerialisationFormat)formatIndex;

            He.Mesh<Euc3D.Point> heMesh = Ser.Deserialise.HalfedgeMesh<Euc3D.Point>(text, format);

            /******************** Set Output ********************/
            DA.SetData(0, heMesh);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{0ABBD26E-2029-4F10-B26A-9908888431C2}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Deserialise; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
