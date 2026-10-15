# Templates

Templates are Razor `.cshtml` views in `Views/` that render a Document Type's content. A layout
(master) template holds the shared HTML shell, and child templates fill it in. See also
[partial-views.md](partial-views.md) for reusable fragments and [razor-basics.md](razor-basics.md)
for the syntax.

## Docs by version (fetch only the one you need, before implementing)

| Version | Page |
|---|---|
| 18 | [Working with Templates](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/templates.md) |
| 17 | [Working with Templates](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/templates.md) |
## Core rules (all versions)

- **Creating:** choose "Document Type with Template" when creating a Document Type, or create a
  standalone template under **Settings → Templates**.
- **Templates are registered in the database.** Adding `Views/foo.cshtml` on its own doesn't create a
  template. Create one in the backoffice with alias `foo` and Umbraco uses the existing file content
  rather than overwriting it.
- **Allow it on the Document Type** (the Document Type's **Templates** view → **Allowed Templates**) or
  content can't use it.
- **Layout inheritance:** the layout sets `Layout = null;` and calls `@RenderBody()`. A child sets
  `Layout = "<LayoutFile>.cshtml";`, and its markup replaces `@RenderBody()` at render time.
- **Named sections:** the child defines `@section Name { ... }`, and the layout renders it with
  `@RenderSection("Name", false)`. Pass `true` to make it mandatory. A missing mandatory section is
  a runtime error on every page using that layout.
- Every template starts with `@inherits Umbraco.Cms.Web.Common.Views.UmbracoViewPage` (or
  `UmbracoViewPage<ContentModels.X>` for a typed model).

## Version differences

- **v18:** the backoffice button is **"Layout template: No layout"**, and the docs say "Layout
  Template".
- **v17:** the same features, but the button is **"Master template: No master"** and the docs say
  "Master Template". Match the label to the user's version when giving backoffice steps.

## Steps

1. Discover: the Umbraco version, existing `Views/` (is there already a layout?), and whether
   ModelsBuilder is on (look for `Umbraco.Cms.Web.Common.PublishedModels` usage).
2. Write the layout (`Layout = null`, `<head>` with an optional section, `@RenderBody()`), then the
   child templates (`Layout = "<Layout>.cshtml"`).
3. Build if a buildable project exists. Otherwise say plainly that nothing was built or run.

## Done

Tell the user which files were created. Also give the version-correct backoffice steps: create or
register each template with an alias matching its file name, allow it on the Document Type, and
pick the layout. Remind them that Production runtime mode blocks backoffice template edits.
