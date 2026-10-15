---
name: umbraco-design-fundamentals
description: >
  Templates, partial views, stylesheets/JS, Razor basics, and rendering content and media for Umbraco
  17 and 18. Use when the user asks to create a template or master/layout template, use
  RenderBody/RenderSection, add a partial view, add CSS/JS, or render a property, image or crop in
  Razor. Also for Umbraco newcomers' goals: "create a design for my Umbraco site", "style my site",
  "use my HTML template/theme", "change the colours/fonts", "same header and footer on every page",
  "add a menu", "reuse HTML on several pages", "build a demo site". Generic phrases count only with
  Umbraco context (Umbraco project present, or Umbraco/backoffice mentioned).
  SKIP: non-Umbraco projects; mockups/graphics with no Umbraco site (Figma, slides); Umbraco < 17;
  headless/Delivery-API-only frontends; sitemaps (umbraco-sitemap); 404/500 pages
  (umbraco-custom-error-pages).
---

# Design Fundamentals

How an Umbraco site gets its look: **templates** (Razor `.cshtml` views tied to Document Types),
**partial views** for reusable HTML, **stylesheets and JavaScript** under `wwwroot`, and Razor code
that **renders content and media** from the backoffice. One reference file per entity, each covering
v17 and v18.

## Load only what the task needs

- **Don't read the whole `references/` folder.** Use the routing table below and open only the
  reference for the entity you're working on, at the moment you start that step. For example, "add a
  stylesheet" needs only `stylesheets-javascript.md`. A demo site needs `templates.md`, then
  `partial-views.md`, then `stylesheets-javascript.md`, opened one at a time as you get to each.
- Inside a reference, **fetch only the doc link for the detected version**, not both.
- Each reference stands alone. Its cross-links are "see also", not prerequisites.
- Ask the docs agent (below) only when the reference and the versioned doc don't answer the question.

## Step 0: detect the version

Read the `Umbraco.Cms` package version from the `.csproj` or `Directory.Packages.props`, then use the
matching docs:

| Version | Docs root | Notes |
|---|---|---|
| **18** | `https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/...` | Unversioned URLs are v18 |
| **17** | `https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/...` | |

If the site is below 17, this skill doesn't apply: say so. If no project or version is available, ask
the user rather than guessing.

## Plain-language map (for people new to Umbraco)

| They say | Umbraco term | Reference |
|---|---|---|
| "the page design / how a page looks" | Template | [templates.md](references/templates.md) |
| "same header and footer on every page" | Layout (master) template + partial views | [templates.md](references/templates.md), [partial-views.md](references/partial-views.md) |
| "a reusable block of HTML", "a menu" | Partial view | [partial-views.md](references/partial-views.md) |
| "my CSS / colours / fonts / scripts" | Stylesheet / script in `wwwroot` | [stylesheets-javascript.md](references/stylesheets-javascript.md) |
| "show what I typed in the backoffice" | Rendering content | [rendering-content.md](references/rendering-content.md) |
| "show an image / gallery / crop" | Rendering media | [rendering-media.md](references/rendering-media.md) |
| "a demo site" | Layout → page templates → partials → stylesheet, in that order | open each as you reach it |

When the user sounds new to Umbraco, explain each term in one plain sentence the first time it comes
up. Also tell them about the backoffice steps code can't do: registering a template and allowing it
on a Document Type.

## Routing table

| Entity | Reference | Versions |
|---|---|---|
| Templates, layouts, `@RenderBody()`, named sections | [templates.md](references/templates.md) | 17, 18 |
| Razor syntax, `UmbracoViewPage<T>`, `@Model` / `@Umbraco` / `@inject` | [razor-basics.md](references/razor-basics.md) | 17, 18 |
| Partial views | [partial-views.md](references/partial-views.md) | 17, 18 |
| Stylesheets, JavaScript | [stylesheets-javascript.md](references/stylesheets-javascript.md) | 17, 18 |
| Property values, fallbacks, querying | [rendering-content.md](references/rendering-content.md) | 17, 18 |
| Media, images, crops, video | [rendering-media.md](references/rendering-media.md) | 17, 18 |

## Version summary

The code is the same on 17 and 18. The differences are backoffice labels and docs wording:

| | v17 | v18 |
|---|---|---|
| Layout button in the template editor | "Master template: No master" | "Layout template: No layout" |
| Partial view Create menu | "Empty partial view from snippet"; folder button "Create" | "Partial view from snippet"; folder button "Create folder" |

Both need the `Umbraco.Cms.DevelopmentMode.Backoffice` package for backoffice view edits to apply
without a rebuild. Per-entity detail is in each reference's **Version differences** section.

## Docs first, and the docs agent

Don't write Umbraco API code from memory. Fetch the versioned `.md` page linked in the reference
first. If that doesn't answer the question, query the GitBook docs agent on the same page:

```
GET <versioned page>.md?ask=<specific question>&goal=<what the user is trying to achieve>
```

## Best practices

- **IDE and source control over backoffice edits.** The backoffice is fine for generating a
  template with a new Document Type or for quick local changes. Ongoing work belongs in `.cshtml` and
  `wwwroot` files under source control. The backoffice editor won't flag C# errors until the page
  renders, and edits on a deployed site can be overwritten by the next deploy. See
  [Managing Views and Assets](https://docs.umbraco.com/umbraco-cms/17.latest/develop-with-umbraco/templating-and-rendering/managing-views-and-assets.md)
  (v17; the v18 page is the same).
- **Production runtime mode blocks** creating, editing, renaming and deleting templates and partial
  views in the backoffice. Don't tell a user to edit views in a production backoffice.
- **Templates live in the database.** A `.cshtml` file in `Views/` isn't a template until one is
  created with an alias matching the file name (Umbraco keeps the existing file content). It must
  also be allowed on the Document Type.
- **Default folders:** `Views` for templates, `Views/Partials` for partial views, `wwwroot/css` for
  stylesheets, `wwwroot/scripts` for scripts.
- **Always use `@inherits Umbraco.Cms.Web.Common.Views.UmbracoViewPage`** (or `<T>`). Never emit
  anything from the legacy `Umbraco.Web.Mvc` namespace, even though the v17/v18 MVC Views page still
  mentions `Umbraco.Web.Mvc.ContentModel`.
- **Prefer ModelsBuilder typed properties** over `Value("alias")` strings when ModelsBuilder is on.
  Null-check media and picked content.
- **Keep views thin.** Render; don't query services or do heavy traversal in Razor.

## Coverage

**Documented.** This skill ships no code (no `assets/`, no `examples/`), so nothing runs in the
`dotnet test` gate. Evals grade the guidance only.

## Validation

Objective assertions live in [`evals/evals.json`](evals/evals.json). Run them with
`umbraco-skill-evaluator`.
