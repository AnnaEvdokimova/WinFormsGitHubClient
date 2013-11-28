using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace GitHubClientWinForm
{
    public class Controller
    {
        public event EventHandler<DataLoadErrorEvenArgs> DataLoadException;

        protected virtual void OnDataLoadException(DataLoadErrorEvenArgs e)
        {
            var handler = DataLoadException;
            if (handler != null) handler(this, e);
        }


        readonly Model _model = new Model();
        readonly GitHubClient _gitHubClient = new GitHubClient(new ProductHeaderValue("MyGitHubClients"));
        public void OnViewInitialized(IView<Model> view)
        {
            view.Model = _model;
        }

        public void OnUserRepositoriesRequest()
        {
            SetRepositoryList();
        }

        private async void SetRepositoryList()
        {
            try
            {

                var repositoryList = await _gitHubClient.Repository.GetAllForUser(_model.UserName);

                var newList =
                    repositoryList.Select(
                        repository => new ContentItem(repository.Id.ToString(), repository.Name))
                                  .ToList();

                _model.RepositoryList = newList;
            }
            catch (NotFoundException)
            {
                OnDataLoadException(new DataLoadErrorEvenArgs("Пользователь не найден"));
            }

        }

        public void SetUser(string userLogin)
        {
            _model.UserName = userLogin;
        }

        public void OnRepositorySelect(object selectedItem)
        {
            _model.SelectedRepository = selectedItem as ContentItem;

            FillRepositoryNodeContent(_model.Branch);
        }

        private async void FillRepositoryNodeContent(string reference)
        {
            if (_model.SelectedRepository != null)
            {
                var treeResponse = await _gitHubClient.Tree.Get(_model.UserName, _model.SelectedRepository.Name, reference);

                _model.RepositoryContentItems = treeResponse.Tree.Select(item => new TreeItem(item.Sha, item.Path, item.Type)).ToList();
            }
        }

        public void OnRepositoryTreeSelect(string nodeSha)
        {
            FillRepositoryNodeContent(nodeSha);
        }
    }
}