using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Core.Web;

namespace <Namespace>.Services;

// No HTTP request (jobs, hosted services): singleton + IUmbracoContextFactory, one disposed
// context per read. Never store the context or content read from it in a field.
public class RootContentReader
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;
    private readonly IDocumentNavigationQueryService _documentNavigationQueryService;

    public RootContentReader(
        IUmbracoContextFactory umbracoContextFactory,
        IDocumentNavigationQueryService documentNavigationQueryService)
    {
        _umbracoContextFactory = umbracoContextFactory;
        _documentNavigationQueryService = documentNavigationQueryService;
    }

    public string? GetSiteRootName()
    {
        using UmbracoContextReference contextReference = _umbracoContextFactory.EnsureUmbracoContext();

        // Tree structure is in memory: root keys without a DB query.
        if (!_documentNavigationQueryService.TryGetRootKeys(out IEnumerable<Guid> rootKeys))
        {
            return null;
        }

        IPublishedContent? root = rootKeys
            .Select(key => contextReference.UmbracoContext.Content?.GetById(key))
            .FirstOrDefault(content => content is not null);

        return root?.Name;
    }
}
