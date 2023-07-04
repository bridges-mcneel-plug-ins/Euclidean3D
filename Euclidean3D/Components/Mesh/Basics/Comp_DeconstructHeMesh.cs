using System;
using System.Collections.Generic;

using Euc3D = BRIDGES.Geometry.Euclidean3D;
using He = BRIDGES.DataStructures.PolyhedralMeshes.HalfedgeMesh;

using GH_Kernel = Grasshopper.Kernel;

using Param = Basics.Components.Parameter;


namespace Basics.Components.Mesh
{
    /// <summary>
    /// A grasshopper component to deconstruct a Halfedge Mesh into data usable in grasshopper.
    /// </summary>
    public class Comp_DeconstructHeMesh : GH_Kernel.GH_Component
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Comp_DeconstructHeMesh"/> class.
        /// </summary>
        public Comp_DeconstructHeMesh()
          : base("Deconstruct HeMesh", "Dec. HeMesh",
              "Deconstructs a halfedge mesh to grasshopper usable datas.",
              Settings.CategoryName, Settings.SubCategoryName[Components.SubCategory.Mesh])
        {
        }

        #endregion

        #region Override : GH_Component

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterInputParams(GH_InputParamManager)"/>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_HeMesh(), "Halfedge Mesh", "HeM", "A halfedge mesh data structure to deconstruct.", GH_Kernel.GH_ParamAccess.item);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.RegisterOutputParams(GH_OutputParamManager)"/>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param.Param_Point(), "Vertex Position", "Vpos", "Position of each vertice.", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Vertex Outgoing Halfedge", "Vout", "Index of one of the outgoing halfedge of each vertice.", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Halfedge Start Vertex", "Hstart", "Index of the start vertex of each halfedge", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Halfedge Previous Halfedge", "Hprev", "Index of the previous halfedge of each halfedge.", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Halfedge Next Halfedge", "Hnext", "Index of the next halfedge of each halfedge.", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Halfedge Adjacent Face", "Hface", "Index of the adjacent face of each halfedge (or -1 if the halfedge is on the boundary).", GH_Kernel.GH_ParamAccess.list);
            pManager.AddIntegerParameter("Face First Halfedge", "Ffirst", "Index of the first halfedge of each face.", GH_Kernel.GH_ParamAccess.list);
        }

        /// <inheritdoc cref="GH_Kernel.GH_Component.SolveInstance(GH_Kernel.IGH_DataAccess)"/>
        protected override void SolveInstance(GH_Kernel.IGH_DataAccess DA)
        {
            /******************** Initialisation ********************/
            He.Mesh<Euc3D.Point> heMesh = new He.Mesh<Euc3D.Point>();

            /******************** Get Inputs ********************/
            if (!DA.GetData(0, ref heMesh)) { return; }

            /******************** Core ********************/
            int vertexCount = heMesh.VertexCount;
            int halfedgeCount = heMesh.HalfedgeCount;
            int faceCount = heMesh.FaceCount;

            List<Euc3D.Point> v_Position = new List<Euc3D.Point>(vertexCount);
            List<int> v_Outgoing = new List<int>(vertexCount);
            foreach (He.Vertex<Euc3D.Point> vertex in heMesh.GetVertices())
            {
                v_Position.Add(vertex.Position);

                int index = vertex.OutgoingHalfedge is null ? -1 : vertex.OutgoingHalfedge.Index;
                v_Outgoing.Add(index);
            }

            List<int> he_StartVertex = new List<int>(halfedgeCount);
            List<int> he_PreviousHe = new List<int>(halfedgeCount);
            List<int> he_NextHe = new List<int>(halfedgeCount);
            List<int> he_AdjacentFace = new List<int>(halfedgeCount);
            foreach (He.Halfedge<Euc3D.Point> halfedge in heMesh.GetHalfedges())
            {
                he_StartVertex.Add(halfedge.StartVertex.Index);
                he_PreviousHe.Add(halfedge.PrevHalfedge.Index);
                he_NextHe.Add(halfedge.NextHalfedge.Index);

                int index = halfedge.AdjacentFace is null ? -1 : halfedge.AdjacentFace.Index;
                he_AdjacentFace.Add(index);
            }

            List<int> f_FirstHe = new List<int>(faceCount);
            foreach (He.Face<Euc3D.Point> face in heMesh.GetFaces())
            {
                f_FirstHe.Add(face.FirstHalfedge.Index);
            }


            /******************** Set Output ********************/
            DA.SetDataList(0, v_Position);
            DA.SetDataList(1, v_Outgoing);
            DA.SetDataList(2, he_StartVertex);
            DA.SetDataList(3, he_PreviousHe);
            DA.SetDataList(4, he_NextHe);
            DA.SetDataList(5, he_AdjacentFace);
            DA.SetDataList(6, f_FirstHe);
        }

        #endregion

        #region Override : GH_DocumentObject

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.ComponentGuid"/>
        public override Guid ComponentGuid
        {
            get { return new Guid("{7F7C2000-11EB-41B0-8C14-4EC9BC45E112}"); }
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
            get { return (GH_Kernel.GH_Exposure)TabExposure.Basics; }
        }

        /// <inheritdoc cref="GH_Kernel.GH_DocumentObject.CreateAttributes()"/>
        public override void CreateAttributes()
        {
            m_attributes = new ComponentAttributes(this);
        }

        #endregion
    }
}
