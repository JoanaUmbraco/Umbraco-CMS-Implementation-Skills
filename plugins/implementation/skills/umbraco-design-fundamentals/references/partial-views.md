# Partial views

A partial view is a reusable `.cshtml` fragment in `Views/Partials` (header, footer, navigation,
breadcrumbs), rendered inside a template. See also [templates.md](templates.md).

## Docs by version (fetch only the one you need, before implementing)

| Version | Pages |
|---|---|
| 18 | [Partial Views](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/design/partial-views.md) · [Using MVC Partial Views](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/templating/mvc/partial-views.md) |
| 17 | [Partial Views](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/design/partial-views.md) · [Using MVC Partial Views](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/templating/mvc/partial-views.md) |
## Core rules (all versions)

- **Create locally:** add `Views/Partials/<name>.cshtml`. The file name is the partial name. Unlike
  templates, partials need **no database registration**.
- **Create in the backoffice:** **Settings → Partial Views → Create**, either empty or from a
  built-in snippet (Breadcrumb, Navigation, List Child Pages…, Login, Site Map, and others). Snippets
  are a good starting point for menus and breadcrumbs.
- **Render** with `@await Html.PartialAsync("~/Views/Partials/Header.cshtml")` or
  `<partial name="~/Views/Partials/Header.cshtml" />`. Pass a model as the second argument or with
  `model="..."` when the partial needs one.
- Give the partial an `@inherits UmbracoViewPage<T>` matching the model you pass.

## Version differences

- **v18:** the Create menu says "Empty partial view", "Partial view from snippet" and "Folder…"
  (the button is "Create folder"). The docs also describe creating partials locally first.
- **v17:** the Create menu says "Empty partial view from snippet", and the folder button is
  "Create". Rendering is the same as v18 (`PartialAsync` / `<partial>`).
- Neither version's docs use the synchronous `Html.Partial()` / `Html.RenderPartial()`, so don't
  generate them.

## Steps

1. Look in `Views/Partials` for existing partials before adding duplicates.
2. Create the partial, then render it from the layout or template.
3. Build if possible. Otherwise say it wasn't verified.

## Done

List each partial and where it's rendered. No backoffice registration is needed.
