using System;
using System.Linq;
using System.Windows.Forms;
using Octokit;

namespace GitHubClientWinForm
{
    public partial class GitHubClientForm : Form, IView<Model>
    {
        readonly Controller _controller = new Controller();

        private Model _model;
        
        public Model Model
        {
            get { return _model; }
            set
            {
                if (_model != null)
                {
                    _model.RepositoryListChanged -= ModelOnRepositoryListChanged;
                    _model.RepositoryContentItemsChanged -= ModelOnRepositoryContentItemsChanged;
                    _controller.DataLoadException -= ControllerOnDataLoadException;
                }

                _model = value;

                if (_model != null)
                {
                    _model.RepositoryListChanged += ModelOnRepositoryListChanged;
                    _controller.DataLoadException += ControllerOnDataLoadException;
                    _model.RepositoryContentItemsChanged += ModelOnRepositoryContentItemsChanged;
                }
            }
        }

        private void ModelOnRepositoryContentItemsChanged(object sender, EventArgs eventArgs)
        {
            AddNodes(tvRepositoryContent.SelectedNode != null
                         ? tvRepositoryContent.SelectedNode.Nodes
                         : tvRepositoryContent.Nodes);

            Enabled = true;
            tvRepositoryContent.Enabled = true;
        }

        private void AddNodes(TreeNodeCollection treeNodeCollection)
        {
            treeNodeCollection.AddRange(
                _model.RepositoryContentItems.Select(item =>
                    {
                        var treeNode = new TreeNode(item.Name) {Tag = item, };

                        return treeNode;

                    }).ToArray());
        }

        private void ControllerOnDataLoadException(object sender, DataLoadErrorEvenArgs dataLoadErrorEvenArgs)
        {
            MessageBox.Show(dataLoadErrorEvenArgs.Message);
            Enabled = true;
        }


        private void ModelOnRepositoryListChanged(object sender, EventArgs eventArgs)
        {
            ClearClientData();

            foreach (var repository in _model.RepositoryList)
            {
                cbRepositoryList.Items.Add(repository);
            }

            Enabled = true;
            cbRepositoryList.DroppedDown = true;
        }

        private void ClearClientData()
        {
            cbRepositoryList.Items.Clear();
            tvRepositoryContent.Nodes.Clear();
        }

        public GitHubClientForm()
        {
            InitializeComponent();
        }

        private void btnGetUserData_Click(object sender, EventArgs e)
        {
            _controller.SetUser(tbUserLogin.Text);
            _controller.OnUserRepositoriesRequest();
            ClearClientData();
            Enabled = false;
        }

        private void GitHubClientForm_Load(object sender, EventArgs e)
        {
            _controller.OnViewInitialized(this);
        }

        private void cbRepositoryList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = ((ComboBox) sender);
            _controller.OnRepositorySelect(comboBox.SelectedItem);
            tvRepositoryContent.Nodes.Clear();
            Enabled = false;
        }

        private void tvRepositoryContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treeItem = (TreeItem)e.Node.Tag;

            if (treeItem.Type == TreeType.Tree && e.Node.Nodes.Count == 0)
            {
                _controller.OnRepositoryTreeSelect(treeItem.Id);

                tvRepositoryContent.Enabled = false;
            }
        }
    }
}
