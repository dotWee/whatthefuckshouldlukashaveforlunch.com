export type Env = {
  CANTEEN_NAME: string;
  WEEKLY_MENU_URL_TEMPLATE: string;
  TIMEZONE: string;
  HTTP_TIMEOUT_SECONDS: string;
  ASSETS: Fetcher;
};

export type CanteenConfig = {
  name: string;
  weeklyMenuUrlTemplate: string;
  timeZone: string;
  httpTimeoutMs: number;
};

export type MenuItem = {
  date: string;
  category: string;
  name: string;
  labels: string;
  studentPrice: string;
  employeePrice: string;
  guestPrice: string;
};

export type LunchSuggestion = {
  item: MenuItem;
  candidateCount: number;
  menuDate: string;
};

export class MensaClosedError extends Error {
  constructor(message: string, options?: { cause?: unknown }) {
    super(message, options);
    this.name = "MensaClosedError";
  }
}
