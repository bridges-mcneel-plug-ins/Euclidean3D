using System;

using Ser = BRIDGES.Serialisation;
using Euc3D = BRIDGES.Geometry.Euclidean3D;
using Fv = BRIDGES.DataStructures.PolyhedralMeshes.FaceVertexMesh;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Serialisation.Serialise
{
    /// <summary>
    /// A grasshopper component to serialise a face|vertex mesh.
    /// </summary>
    public class Comp_SerialiseFvMesh : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_SerialiseFvMesh"/> class.
        /// </summary>
        public Comp_SerialiseFvMesh()
          : base("Serialise FvMesh", "Ser. FvMesh",
              "Serialises a face|vertex mesh into a formatted text.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Serialisation])
        {
            /* Do Nothing */
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_FvMesh(), "Face|vertex Mesh", "FvM", "Face|vertex mesh to serialise.", GH_Kernel.GH_ParamAccess.item);
            pManager.AddIntegerParameter("File Format", "F", "File format for the serialisation of the face|vertex mesh.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Formatted Text", "T", "Text representation of the face|vertex mesh.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            Fv.Mesh<Euc3D.Point> fvMesh = new Fv.Mesh<Euc3D.Point>();
            int formatIndex = 0;


            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref fvMesh)) { return; }
            if (!DA.GetData(1, ref formatIndex)) { return; }


            /******************** Core ********************/

            Ser.PolyhedralMeshSerialisationFormat format = (Ser.PolyhedralMeshSerialisationFormat)formatIndex;

            string text = Ser.Serialise.FaceVertexMesh(fvMesh, format);

            /******************** Set Output ********************/
            DA.SetData(0, text);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{96D2FF0B-45AE-4D7D-9F96-80942D598568}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Serialise; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
