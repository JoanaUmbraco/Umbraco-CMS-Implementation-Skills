# Rendering content

Showing the current page's property values, with fallbacks, and querying related content such as
child pages and ancestors. See also [rendering-media.md](rendering-media.md) and
[razor-basics.md](razor-basics.md).

## Docs by version (fetch only the one you need, before implementing)

| Version | Pages |
|---|---|
| 18 | [Rendering Content](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/design/rendering-content.md) · [Querying](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/querying/querying.md) |
| 17 | [Rendering Content](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/design/rendering-content.md) · [Querying](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/querying/querying.md) |
## Core rules (all versions)

- **By alias:** `@Model.Value("pageTitle")`. **Typed:** `@(Model.Value<string>("pageTitle"))`,
  `@(Model.Value<IHtmlEncodedString>("bodyContent"))` (needs `@using Umbraco.Cms.Core.Strings;`), and
  `Value<DateTime>`.
- **ModelsBuilder (preferred when on):** `@Model.PageTitle`, `@Model.BodyContent`.
- **Fallbacks** (need `@using Umbraco.Cms.Core.Models.PublishedContent;`):
  - `Fallback.ToDefaultValue` (with `defaultValue:`)
  - `Fallback.ToAncestors`
  - `Fallback.ToLanguage` (needs fallback languages configured)
  - Combined: `Fallback.To(Fallback.Language, Fallback.Ancestors)`, where order matters.
  - With ModelsBuilder: `Model.ValueFor(x => x.PageTitle, fallback: ...)` (projects after Jan 2020).
- **Querying:** `Model.Children()`, `Ancestors()`, `Descendants()`, plus `Url()` / `Name()` for links.
  Avoid `Descendants()` over large trees on every request.

## Version differences

None between 17 and 18: the pages match apart from doc link paths. Rich, editor-composed layouts use
Block List or Block Grid.

## Steps

1. Check the Document Type's property aliases (or ModelsBuilder models) before writing.
2. Render with typed access and add fallbacks where content may be empty.
3. Build if possible. Otherwise say it wasn't verified.

## Done

List which properties render where, and any fallback behaviour the editor should know about.
