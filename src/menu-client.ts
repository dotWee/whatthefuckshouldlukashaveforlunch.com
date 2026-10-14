import { stwnoWeekNumber, type CalendarDate } from "./dates.ts";
import { MensaClosedError, type CanteenConfig } from "./types.ts";

export async function fetchWeeklyMenu(
  config: CanteenConfig,
  date: CalendarDate,
  fetcher: typeof fetch = fetch,
): Promise<string> {
  const weekNumber = stwnoWeekNumber(date);
  const requestUri = config.weeklyMenuUrlTemplate.replace("{weekNumber}", String(weekNumber));

  try {
    const response = await fetcher(requestUri, {
      signal: AbortSignal.timeout(config.httpTimeoutMs),
    });

    if (!response.ok) {
      throw new MensaClosedError("The canteen menu could not be loaded.");
    }

    const bytes = await response.arrayBuffer();
    return new TextDecoder("iso-8859-1").decode(bytes);
  } catch (error) {
    if (error instanceof MensaClosedError) {
      throw error;
    }

    throw new MensaClosedError("The canteen menu could not be loaded.", { cause: error });
  }
}
