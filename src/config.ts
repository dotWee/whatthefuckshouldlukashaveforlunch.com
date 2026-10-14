import type { CanteenConfig, Env } from "./types.ts";

export function readConfig(env: Env): CanteenConfig {
  const timeoutSeconds = Number.parseInt(env.HTTP_TIMEOUT_SECONDS ?? "10", 10);

  return {
    name: env.CANTEEN_NAME || "OTH Regensburg canteen",
    weeklyMenuUrlTemplate:
      env.WEEKLY_MENU_URL_TEMPLATE ||
      "http://www.stwno.de/infomax/daten-extern/csv/UNI-R/{weekNumber}.csv",
    timeZone: env.TIMEZONE || "Europe/Berlin",
    httpTimeoutMs: Number.isFinite(timeoutSeconds)
      ? Math.min(60, Math.max(1, timeoutSeconds)) * 1000
      : 10_000,
  };
}
