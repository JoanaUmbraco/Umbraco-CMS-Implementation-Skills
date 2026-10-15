# Razor basics

The Razor syntax Umbraco views use, and what a view has access to. See also
[templates.md](templates.md), [rendering-content.md](rendering-content.md) and
[rendering-media.md](rendering-media.md).

## Docs by version (fetch only the one you need, before implementing)

| Version | Pages |
|---|---|
| 18 | [Working with MVC Views](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/templating/mvc/views.md) · [View/Razor Examples](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/templating/mvc/examples.md) |
| 17 | [Working with MVC Views](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/templating/mvc/views.md) · [View/Razor Examples](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/templating/mvc/examples.md) |
## Core rules (all versions)

- **Base class:** `@inherits Umbraco.Cms.Web.Common.Views.UmbracoViewPage<ContentModels.MyDocType>`
  with `@using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;`. Use the untyped
  `UmbracoViewPage` when no generated model fits.
- **Available in every view:**
  - `@Model` is the current page (typed when `<T>` is given).
  - `@Umbraco` is the `UmbracoHelper` (for example, `Umbraco.Media(...)`).
  - `@Html` is the `HtmlHelper` plus Umbraco extensions such as `BeginUmbracoForm`.
  - `@UmbracoContext` is the request's Umbraco context.
- **Services in a view:** `@inject` (for example, `@inject IMemberManager MemberManager`). Keep this
  light; heavy logic belongs in controllers or view components.
- **Syntax essentials:**
  - `@` starts code.
  - `@* ... *@` is a comment.
  - `@{ ... }` is a code block.
  - `@if` / `@foreach` / `@switch` are control flow.
  - `@(expr)` is an explicit expression, needed for generics like `@(Model.Value<string>("x"))`.
- In a **partial**, declare the model type with `@inherits UmbracoViewPage<T>` so typed properties
  resolve.

## Version differences

- **v17 / v18:** the MVC Views page still says `@Model` is "of type `Umbraco.Web.Mvc.ContentModel`".
  That's a legacy reference, so don't emit that type. `@Model` is the typed published model. The
  pages are otherwise the same on 17 and 18.

## Steps

1. Detect the version and ModelsBuilder mode.
2. Write views with the correct `@inherits` and `@using`.
3. Build if possible. Otherwise state that nothing was compiled.

## Done

Explain any Razor construct you introduced in one line if the user is new to Razor.
