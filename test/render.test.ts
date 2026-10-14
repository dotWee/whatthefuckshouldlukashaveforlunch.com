import { describe, expect, it } from "vitest";
import { layout, renderClosed, renderSuggestion } from "../src/html.ts";
import { escapeHtml, render } from "../src/templates/render.ts";

describe("render", () => {
  it("escapes interpolated values", () => {
    expect(escapeHtml(`<script>"x"</script>`)).toBe(
      "&lt;script&gt;&quot;x&quot;&lt;/script&gt;",
    );
    expect(render("<p>{{name}}</p>", { name: "<b>Lukas</b>" })).toBe(
      "<p>&lt;b&gt;Lukas&lt;/b&gt;</p>",
    );
  });

  it("leaves triple-stache fragments unescaped", () => {
    expect(render("<main>{{{body}}}</main>", { body: "<h1>Hi</h1>" })).toBe(
      "<main><h1>Hi</h1></main>",
    );
  });
});

describe("page templates", () => {
  it("wraps a page body in the layout template", () => {
    const html = layout("Privacy", "<article>notes</article>");

    expect(html).toContain("<title>Privacy - what the fuck should lukas have for lunch?</title>");
    expect(html).toContain("<article>notes</article>");
  });

  it("fills the suggestion template from menu data", () => {
    const html = renderSuggestion("OTH Regensburg canteen", {
      candidateCount: 3,
      menuDate: "2026-05-11",
      item: {
        date: "2026-05-11",
        category: "HG1",
        name: 'Tofu"Bacon"',
        labels: "VG",
        studentPrice: "2,30",
        employeePrice: "3,30",
        guestPrice: "6,10",
      },
    });

    expect(html).toContain(
      '<a href="https://www.oth-regensburg.de" rel="noreferrer">OTH Regensburg</a> canteen',
    );
    expect(html).toContain("Tofu&quot;Bacon&quot;");
    expect(html).toContain("2,30 €");
    expect(html).toContain("Monday, 11 May 2026");
  });

  it("links the university name on the closed page without trusting the rest of the label", () => {
    const html = renderClosed("<OTH Regensburg>");

    expect(html).toContain(
      '&lt;<a href="https://www.oth-regensburg.de" rel="noreferrer">OTH Regensburg</a>&gt;',
    );
  });
});
