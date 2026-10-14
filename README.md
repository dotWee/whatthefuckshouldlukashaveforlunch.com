# whatthefuckshouldlukashaveforlunch

[![GitHub License](https://img.shields.io/github/license/dotWee/whatthefuckshouldlukashaveforlunch.com)](./LICENSE)

_what the fuck should lukas have for lunch?_

This is a Cloudflare Worker that picks a random dish from the [OTH Regensburg](https://www.oth-regensburg.de) canteen menu for today.

## Tech Stack

- Cloudflare Workers with [Wrangler](https://developers.cloudflare.com/workers/wrangler/)
- [Hono](https://hono.dev/) for routing and HTML responses
- STWNO weekly CSV feed fetched at the edge
- Vitest for menu parsing and suggestion behavior
- GitHub Actions CI

## How It Works

1. The worker resolves today's date in `Europe/Berlin`.
2. It computes the STWNO week number (Monday-based, week 1 starts on the first Monday of the year) and downloads the weekly CSV:
   `http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{weekNumber}.csv`
3. The parser decodes the Latin-1 feed, reads semicolon-separated rows, filters the `datum` column to today, and cleans bracketed allergen annotations from dish names.
4. A uniformly random dish is selected and displayed.
5. If the feed cannot be loaded or no meal exists for today, the user is redirected to `/closed`.

## Configuration

Canteen settings live in `wrangler.jsonc` as Worker vars:

```jsonc
{
  "vars": {
    "CANTEEN_NAME": "OTH Regensburg canteen",
    "WEEKLY_MENU_URL_TEMPLATE": "http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{weekNumber}.csv",
    "TIMEZONE": "Europe/Berlin",
    "HTTP_TIMEOUT_SECONDS": "10"
  }
}
```

Override them per environment with `wrangler.jsonc` env blocks or `wrangler secret` / dashboard variables.

## Development

Requires Node.js 24 or newer.

```bash
npm install
npm run dev
```

Then open [localhost:8787](http://localhost:8787).

Run the quality gate (typecheck, ESLint, tests):

```bash
npm run check
```

The worker exposes a health endpoint at `/healthz`.

## Deploy

```bash
npm run deploy
```

## Project Structure

- `src/` contains the Worker, CSV parser, date helpers, and HTML templates.
- `public/` contains static assets served by Workers Assets.
- `test/` contains Vitest coverage for parsing, dates, selection, and suggestion flow.

## License

Copyright (c) 2016 Lukas 'dotwee' Wolfsteiner <lukas@wolfsteiner.media>

Licensed under the [_Do What The Fuck You Want To_](/LICENSE) public license.
