import { describe, expect, it } from "vitest";
import { getLunchSuggestion } from "../src/suggest.ts";
import { MensaClosedError, type CanteenConfig } from "../src/types.ts";

const config: CanteenConfig = {
  name: "OTH Regensburg canteen",
  weeklyMenuUrlTemplate: "https://example.test/{weekNumber}.csv",
  timeZone: "Europe/Berlin",
  httpTimeoutMs: 1000,
};

const csv = `datum;tag;warengruppe;name;kennz;preis;stud;bed;gast
11.05.2026;Mo;HG1;Broccoli Nudelauflauf (3,AA);VG;2,30 / 3,30 / 6,10;2,30;3,30;6,10
11.05.2026;Mo;HG2;Rosmarinkartoffeln (I);VG;3,80 / 4,70 / 7,10;3,80;4,70;7,10`;

describe("getLunchSuggestion", () => {
  it("returns a selected dish with the candidate count", async () => {
    const suggestion = await getLunchSuggestion(
      config,
      new Date("2026-05-11T12:00:00+02:00"),
      () =>
        Promise.resolve(
          new Response(new TextEncoder().encode(csv), {
            status: 200,
            headers: { "content-type": "text/csv" },
          }),
        ),
    );

    expect(suggestion.candidateCount).toBe(2);
    expect(suggestion.menuDate).toBe("2026-05-11");
    expect(["Broccoli Nudelauflauf", "Rosmarinkartoffeln"]).toContain(suggestion.item.name);
  });

  it("throws when no menu items exist for today", async () => {
    await expect(
      getLunchSuggestion(
        config,
        new Date("2026-05-11T12:00:00+02:00"),
        () =>
          Promise.resolve(
            new Response(
              "datum;tag;warengruppe;name;kennz;preis;stud;bed;gast\n12.05.2026;Di;HG1;Kartoffelgulasch (I);VG;2,20;2,20;3,20;5,90",
              { status: 200 },
            ),
          ),
      ),
    ).rejects.toBeInstanceOf(MensaClosedError);
  });

  it("throws when the feed cannot be loaded", async () => {
    await expect(
      getLunchSuggestion(config, new Date("2026-05-11T12:00:00+02:00"), () =>
        Promise.reject(new Error("network down")),
      ),
    ).rejects.toThrow("The canteen menu could not be loaded.");
  });
});
