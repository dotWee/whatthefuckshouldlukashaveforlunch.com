import { describe, expect, it } from "vitest";
import { parseWeeklyMenu } from "../src/parse.ts";

const csv = `datum;tag;warengruppe;name;kennz;preis;stud;bed;gast
11.05.2026;Mo;HG1;Broccoli Nudelauflauf mit Tofu"Bacon" (3,AA,F,I);VG,PHD;2,30 / 3,30 / 6,10;2,30;3,30;6,10
11.05.2026;Mo;Suppe;Grüne Bohnensuppe (3,I);VG;0,80 / 1,00 / 1,50;0,80;1,00;1,50
12.05.2026;Di;HG1;Kartoffelgulasch (I);VG;2,20 / 3,20 / 5,90;2,20;3,20;5,90`;

describe("parseWeeklyMenu", () => {
  it("extracts and cleans menu items for the requested date", () => {
    const result = parseWeeklyMenu(csv, { year: 2026, month: 5, day: 11 });

    expect(result).toEqual([
      {
        date: "2026-05-11",
        category: "HG1",
        name: 'Broccoli Nudelauflauf mit Tofu"Bacon"',
        labels: "VG,PHD",
        studentPrice: "2,30",
        employeePrice: "3,30",
        guestPrice: "6,10",
      },
      {
        date: "2026-05-11",
        category: "Suppe",
        name: "Grüne Bohnensuppe",
        labels: "VG",
        studentPrice: "0,80",
        employeePrice: "1,00",
        guestPrice: "1,50",
      },
    ]);
  });

  it("returns an empty list when the requested date is missing", () => {
    const result = parseWeeklyMenu(csv, { year: 2026, month: 5, day: 11 });
    const otherDay = parseWeeklyMenu(
      `datum;tag;warengruppe;name;kennz;preis;stud;bed;gast
12.05.2026;Di;HG1;Kartoffelgulasch (I);VG;2,20 / 3,20 / 5,90;2,20;3,20;5,90`,
      { year: 2026, month: 5, day: 11 },
    );

    expect(result).toHaveLength(2);
    expect(otherDay).toEqual([]);
  });
});
