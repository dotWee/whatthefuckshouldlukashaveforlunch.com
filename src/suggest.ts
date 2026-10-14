import { calendarDateToIso, todayInTimeZone } from "./dates.ts";
import { fetchWeeklyMenu } from "./menu-client.ts";
import { parseWeeklyMenu } from "./parse.ts";
import { selectRandomItem } from "./select.ts";
import { MensaClosedError, type CanteenConfig, type LunchSuggestion } from "./types.ts";

export async function getLunchSuggestion(
  config: CanteenConfig,
  now = new Date(),
  fetcher: typeof fetch = fetch,
): Promise<LunchSuggestion> {
  const today = todayInTimeZone(config.timeZone, now);
  const weeklyMenu = await fetchWeeklyMenu(config, today, fetcher);
  const menuItems = parseWeeklyMenu(weeklyMenu, today);

  if (menuItems.length === 0) {
    throw new MensaClosedError("The canteen has no meals for today.");
  }

  return {
    item: selectRandomItem(menuItems),
    candidateCount: menuItems.length,
    menuDate: calendarDateToIso(today),
  };
}
