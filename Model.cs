using System;
using System.Collections.Generic;

namespace GitHubClientWinForm
{
    public class Model
    {
        private IList<ContentItem> _repositoryList;
        private string _userName;
        private IList<TreeItem> _repositoryContentItems;
        public event EventHandler RepositoryListChanged;
        public event EventHandler RepositoryContentItemsChanged;

        protected virtual void OnRepositoryContentItemsChanged()
        {
            var handler = RepositoryContentItemsChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnRepositoryListChanged()
        {
            var handler = RepositoryListChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                ClearUserData();
            }
        }

        public IList<TreeItem> RepositoryContentItems
        {
            get { return _repositoryContentItems; }
            set
            {
                _repositoryContentItems = value;

                OnRepositoryContentItemsChanged();
            }
        }

        public IList<ContentItem> RepositoryList
        {
            get { return _repositoryList; }
            set
            {
                _repositoryList = value;

                OnRepositoryListChanged();
            }
        }

        public ContentItem SelectedRepository { get; set; }

        public string Branch { get { return "master"; } }

        protected void ClearUserData()
        {
            if (_repositoryList != null)
                _repositoryList.Clear();

            if (_repositoryContentItems != null)
                _repositoryContentItems.Clear();
        }
    }

}