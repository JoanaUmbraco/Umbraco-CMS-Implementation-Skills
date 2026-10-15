# Stylesheets and JavaScript

CSS and JS are static files under `wwwroot`, referenced from a layout or template. See also
[templates.md](templates.md) for where to put the `<link>` / `<script>` tags.

## Docs by version (fetch only the one you need, before implementing)

| Version | Pages |
|---|---|
| 18 | [Stylesheets and JavaScript](https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/templating-and-rendering/design/stylesheets-javascript.md) · [RTE Style Menu](https://docs.umbraco.com/umbraco-cms/model-your-content/property-editors/built-in-umbraco-property-editors/rich-text-editor/style-menu.md) |
| 17 | [Stylesheets and JavaScript](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/design/stylesheets-javascript.md) · [RTE Style Menu](https://docs.umbraco.com/umbraco-cms/17.latest/model-your-content/property-editors/built-in-umbraco-property-editors/rich-text-editor/style-menu.md) |
## Core rules (all versions)

- **Locations:** stylesheets go in `wwwroot/css` and scripts in `wwwroot/scripts` by default. Any path
  under `wwwroot` is served. The backoffice only lists the folders set by `UmbracoCssPath` and
  `UmbracoScriptsPath`.
- **Reference from the layout:** `<link rel="stylesheet" href="/css/site.css" />` (or
  `@Url.Content("~/css/site.css")`) in `<head>`, and `<script src="/scripts/site.js"></script>`
  before `</body>`. A named section lets one page add its own assets (see [templates.md](templates.md)).
- **Files added outside the backoffice** in those folders appear after **⋯ → Reload children** on the
  Stylesheets/Scripts folder.
- **Third-party CSS/JS** (Bootstrap, Tailwind output, and so on) works the same way: put the built
  files under `wwwroot`, or link a CDN, and reference them from the layout.
- **The Rich Text Editor doesn't pick up site CSS automatically.** Editor styles are configured in
  the RTE configuration. Site CSS still has to exist for the frontend.

## Version differences

None between 17 and 18. On both, the backoffice create flow is **Settings → Stylesheets (or
Scripts) → ⋯ → Create → Stylesheet file / JavaScript file**, and RTE styles come from the **Style
Menu** configuration. Neither page documents built-in bundling or minification. If the user wants
it, use the project's own front-end build (npm, Vite, webpack…) and reference the output files from
`wwwroot`.

## Steps

1. Check for an existing `wwwroot/css` / `wwwroot/scripts` and a layout `<head>`.
2. Add the files and reference them once, in the layout.
3. Build/run if possible. Otherwise say it wasn't verified.

## Done

Give the file paths and the URLs they're served from (`/css/...`, `/scripts/...`).
