import { calendarDateToIso, parseGermanDate, sameDate, type CalendarDate } from "./dates.ts";
import type { MenuItem } from "./types.ts";

export function parseWeeklyMenu(csvContent: string, date: CalendarDate): MenuItem[] {
  if (!csvContent.trim()) {
    return [];
  }

  const rows = csvContent
    .split(/\r?\n/)
    .map((line) => line.trim())
    .filter((line) => line.length > 0)
    .map(splitSemicolonRow)
    .filter((row) => row.length > 0);

  if (rows.length < 2) {
    return [];
  }

  const headerRow = rows[0] ?? [];
  const header = new Map<string, number>();

  headerRow.forEach((name, index) => {
    header.set(normalizeHeader(name).toLowerCase(), index);
  });

  const menuItems: MenuItem[] = [];

  for (const row of rows.slice(1)) {
    const rawDate = readColumn(row, header, "datum");
    const parsedDate = rawDate ? parseGermanDate(rawDate) : undefined;
    const rawName = readColumn(row, header, "name");

    if (!parsedDate || !sameDate(parsedDate, date) || rawName === undefined) {
      continue;
    }

    const name = cleanDishName(rawName);
    if (!name) {
      continue;
    }

    menuItems.push({
      date: calendarDateToIso(parsedDate),
      category: readColumn(row, header, "warengruppe")?.trim() ?? "",
      name,
      labels: readColumn(row, header, "kennz")?.trim() ?? "",
      studentPrice: readColumn(row, header, "stud")?.trim() ?? "",
      employeePrice: readColumn(row, header, "bed")?.trim() ?? "",
      guestPrice: readColumn(row, header, "gast")?.trim() ?? "",
    });
  }

  return menuItems;
}

function cleanDishName(rawName: string): string {
  return rawName
    .replace(/\s*\([^)]*\)/g, "")
    .replace(/\s+/g, " ")
    .trim();
}

function normalizeHeader(header: string): string {
  return header.trim().replace(/^\uFEFF/, "");
}

function readColumn(
  row: string[],
  header: Map<string, number>,
  name: string,
): string | undefined {
  const index = header.get(name);
  if (index === undefined || index >= row.length) {
    return undefined;
  }

  return row[index];
}

function splitSemicolonRow(row: string): string[] {
  const columns: string[] = [];
  let current = "";
  let insideQuotedValue = false;

  for (let index = 0; index < row.length; index += 1) {
    const character = row[index];

    if (character === '"') {
      if (!insideQuotedValue && current.length > 0) {
        current += character;
        continue;
      }

      if (insideQuotedValue && row[index + 1] === '"') {
        current += character;
        index += 1;
        continue;
      }

      insideQuotedValue = !insideQuotedValue;
      continue;
    }

    if (character === ";" && !insideQuotedValue) {
      columns.push(current.trim());
      current = "";
      continue;
    }

    current += character;
  }

  columns.push(current.trim());
  return columns;
}
