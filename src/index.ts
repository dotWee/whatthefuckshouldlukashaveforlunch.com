import { Hono } from "hono";
import { readConfig } from "./config.ts";
import {
  layout,
  renderClosed,
  renderError,
  renderPrivacy,
  renderSuggestion,
} from "./html.ts";
import { getLunchSuggestion } from "./suggest.ts";
import { MensaClosedError, type Env } from "./types.ts";

const app = new Hono<{ Bindings: Env }>();

app.get("/healthz", (c) => c.text("ok"));

app.get("/privacy", (c) =>
  c.html(layout("Privacy", renderPrivacy()), 200, {
    "Cache-Control": "no-store",
  }),
);

app.get("/closed", (c) => {
  const config = readConfig(c.env);
  return c.html(layout("no fucking lunch today", renderClosed(config.name)), 200, {
    "Cache-Control": "no-store",
  });
});

app.get("/", async (c) => {
  const config = readConfig(c.env);

  try {
    const suggestion = await getLunchSuggestion(config);
    return c.html(layout("fucking index", renderSuggestion(config.name, suggestion)), 200, {
      "Cache-Control": "no-store",
    });
  } catch (error) {
    if (error instanceof MensaClosedError) {
      return c.redirect("/closed");
    }

    throw error;
  }
});

app.notFound((c) => c.html(layout("Error", renderError()), 404));

app.onError((error, c) => {
  console.error(error);
  return c.html(layout("fucking error", renderError(c.req.header("cf-ray"))), 500);
});

export default app;
