using RightNow.AddIns.AddInViews;
using System.AddIn;
using System.Windows.Forms;

////////////////////////////////////////////////////////////////////////////////
//
// File: WorkspaceRibbonAddIn.cs
//
// Comments:
//
// Notes: 
//
// Pre-Conditions: 
//
////////////////////////////////////////////////////////////////////////////////
namespace JiraTicketButton
{
    public class WorkspaceRibbonAddIn : Panel, IWorkspaceRibbonButton
    {
        /// <summary>
        /// The current workspace record context.
        /// </summary>
        private IRecordContext RecordContext { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="inDesignMode">Flag which indicates if the control is being drawn on the Workspace designer.</param>
        /// <param name="RecordContext">The current workspace record context.</param>
        public WorkspaceRibbonAddIn(bool inDesignMode, IRecordContext RecordContext)
        {
            this.RecordContext = RecordContext;
        }

        #region IWorkspaceRibbonButton Members

        /// <summary>
        /// This method is invoked when the ribbon button is clicked.
        /// </summary>
        public new void Click()
        {
            MessageBox.Show("Clicked");
        }

        #endregion
    }

    [AddIn("Workspace Ribbon Button AddIn", Version = "1.0.0.0")]
    public class WorkspaceRibbonButtonFactory : IWorkspaceRibbonButtonFactory
    {

        #region IWorkspaceRibbonButtonFactory Members

        /// <summary>
        /// Method which is invoked by the AddIn framework when the control is created.
        /// </summary>
        /// <param name="inDesignMode">Flag which indicates if the control is being drawn on the Workspace Designer. (Use this flag to determine if code should perform any logic on the workspace record)</param>
        /// <param name="RecordContext">The current workspace record context.</param>
        /// <returns>The control which implements the IWorkspaceComponent2 interface.</returns>
        public IWorkspaceRibbonButton CreateControl(bool inDesignMode, IRecordContext RecordContext)
        {
            return new WorkspaceRibbonAddIn(inDesignMode, RecordContext);
        }

        /// <summary>
        /// The 32x32 pixel icon displayed in the Workspace Ribbon.
        /// </summary>
        public System.Drawing.Image Image32
        {
            get { return Properties.Resources.AddIn32; }
        }

        #endregion

        #region IFactoryBase Members

        /// <summary>
        /// The 16x16 pixel icon to represent the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public System.Drawing.Image Image16
        {
            get { return Properties.Resources.AddIn16; }
        }

        /// <summary>
        /// The text to represent the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public string Text
        {
            get { return "Workspace Ribbon Button"; }
        }

        /// <summary>
        /// The tooltip displayed when hovering over the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public string Tooltip
        {
            get { return "Workspace Ribbon Button Tooltip."; }
        }

        #endregion

        #region IAddInBase Members

        /// <summary>
        /// Method which is invoked from the Add-In framework and is used to programmatically control whether to load the Add-In.
        /// </summary>
        /// <param name="GlobalContext">The Global Context for the Add-In framework.</param>
        /// <returns>If true the Add-In to be loaded, if false the Add-In will not be loaded.</returns>
        public bool Initialize(IGlobalContext GlobalContext)
        {
            return true;
        }

        #endregion
    }
}