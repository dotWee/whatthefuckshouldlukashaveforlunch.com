import { describe, expect, it } from "vitest";
import { selectRandomItem } from "../src/select.ts";
import { MensaClosedError, type MenuItem } from "../src/types.ts";

const items: MenuItem[] = [
  {
    date: "2026-05-11",
    category: "HG1",
    name: "Item 1",
    labels: "VG",
    studentPrice: "2,30",
    employeePrice: "3,30",
    guestPrice: "6,10",
  },
  {
    date: "2026-05-11",
    category: "HG2",
    name: "Item 2",
    labels: "",
    studentPrice: "3,80",
    employeePrice: "4,70",
    guestPrice: "7,10",
  },
];

describe("selectRandomItem", () => {
  it("returns an item from the provided list", () => {
    expect(items).toContainEqual(selectRandomItem(items));
  });

  it("returns the only item when there is one candidate", () => {
    expect(selectRandomItem([items[0] as MenuItem])).toEqual(items[0]);
  });

  it("throws when no items are provided", () => {
    expect(() => selectRandomItem([])).toThrow(MensaClosedError);
    expect(() => selectRandomItem([])).toThrow("The canteen has no meals for today.");
  });
});
