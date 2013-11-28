using Octokit;

namespace GitHubClientWinForm
{
    public class ContentItem
    {
        public ContentItem(string id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TreeItem : ContentItem
    {
        public TreeType Type { get; private set; }
        public TreeItem(string id, string name, TreeType type) : base(id, name)
        {
            Type = type;
        }
    }
}