import { describe, expect, it } from "vitest";
import { calendarDateToIso, stwnoWeekNumber, todayInTimeZone } from "../src/dates.ts";

describe("todayInTimeZone", () => {
  it("returns the calendar date in the configured time zone", () => {
    const now = new Date("2026-05-11T12:00:00+02:00");
    expect(calendarDateToIso(todayInTimeZone("Europe/Berlin", now))).toBe("2026-05-11");
  });

  it("crosses the Berlin midnight boundary from UTC", () => {
    const now = new Date("2026-05-11T22:00:00Z");
    expect(calendarDateToIso(todayInTimeZone("Europe/Berlin", now))).toBe("2026-05-12");
  });
});

describe("stwnoWeekNumber", () => {
  it("uses the first Monday of the year as week 1", () => {
    expect(stwnoWeekNumber({ year: 2026, month: 1, day: 7 })).toBe(1);
    expect(stwnoWeekNumber({ year: 2026, month: 5, day: 11 })).toBe(19);
    expect(stwnoWeekNumber({ year: 2026, month: 10, day: 14 })).toBe(41);
  });
});
