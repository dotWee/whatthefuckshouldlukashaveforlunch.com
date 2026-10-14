export type CalendarDate = {
  year: number;
  month: number;
  day: number;
};

export function todayInTimeZone(timeZone: string, now = new Date()): CalendarDate {
  const parts = new Intl.DateTimeFormat("en-US", {
    timeZone,
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
  }).formatToParts(now);

  const year = Number(parts.find((part) => part.type === "year")?.value);
  const month = Number(parts.find((part) => part.type === "month")?.value);
  const day = Number(parts.find((part) => part.type === "day")?.value);

  return { year, month, day };
}

export function calendarDateToIso(date: CalendarDate): string {
  return `${date.year.toString().padStart(4, "0")}-${date.month
    .toString()
    .padStart(2, "0")}-${date.day.toString().padStart(2, "0")}`;
}

export function parseGermanDate(value: string): CalendarDate | undefined {
  const match = /^(\d{2})\.(\d{2})\.(\d{4})$/.exec(value.trim());
  if (!match) {
    return undefined;
  }

  return {
    day: Number(match[1]),
    month: Number(match[2]),
    year: Number(match[3]),
  };
}

export function sameDate(left: CalendarDate, right: CalendarDate): boolean {
  return left.year === right.year && left.month === right.month && left.day === right.day;
}

export function stwnoWeekNumber(date: CalendarDate): number {
  const utc = Date.UTC(date.year, date.month - 1, date.day);
  const jan1 = new Date(Date.UTC(date.year, 0, 1));
  const jan1Weekday = jan1.getUTCDay() || 7;
  const firstMondayOffset = jan1Weekday === 1 ? 0 : 8 - jan1Weekday;
  const firstMonday = Date.UTC(date.year, 0, 1 + firstMondayOffset);

  if (utc < firstMonday) {
    return stwnoWeekNumber({ year: date.year - 1, month: 12, day: 31 });
  }

  return Math.floor((utc - firstMonday) / 86_400_000 / 7) + 1;
}

export function formatLongDate(isoDate: string): string {
  const [year, month, day] = isoDate.split("-").map(Number);
  const date = new Date(Date.UTC(year ?? 0, (month ?? 1) - 1, day ?? 1));

  return new Intl.DateTimeFormat("en-GB", {
    weekday: "long",
    day: "2-digit",
    month: "long",
    year: "numeric",
    timeZone: "UTC",
  }).format(date);
}
