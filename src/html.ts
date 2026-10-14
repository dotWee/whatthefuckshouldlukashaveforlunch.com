import { formatLongDate } from "./dates.ts";
import closedTemplate from "./templates/closed.html";
import errorTemplate from "./templates/error.html";
import labelsTemplate from "./templates/labels.html";
import layoutTemplate from "./templates/layout.html";
import priceRowTemplate from "./templates/price-row.html";
import privacyTemplate from "./templates/privacy.html";
import { escapeHtml, render } from "./templates/render.ts";
import requestIdTemplate from "./templates/request-id.html";
import suggestionTemplate from "./templates/suggestion.html";
import type { LunchSuggestion } from "./types.ts";

const UNIVERSITY_LABEL = "OTH Regensburg";
const UNIVERSITY_URL = "https://www.oth-regensburg.de";

export function layout(title: string, body: string): string {
  return render(layoutTemplate, { title, body });
}

function linkUniversityMentions(value: string): string {
  const label = escapeHtml(UNIVERSITY_LABEL);
  const link = `<a href="${UNIVERSITY_URL}" rel="noreferrer">${label}</a>`;
  return escapeHtml(value).replaceAll(label, link);
}

export function renderSuggestion(canteenName: string, suggestion: LunchSuggestion): string {
  const labels = suggestion.item.labels
    ? render(labelsTemplate, { labels: suggestion.item.labels })
    : "";

  return render(suggestionTemplate, {
    canteenName: linkUniversityMentions(canteenName),
    dishName: suggestion.item.name,
    category: suggestion.item.category,
    labels,
    prices: [
      priceRow("Students", suggestion.item.studentPrice),
      priceRow("Staff", suggestion.item.employeePrice),
      priceRow("Guests", suggestion.item.guestPrice),
    ].join(""),
    candidateCount: String(suggestion.candidateCount),
    menuDate: formatLongDate(suggestion.menuDate),
  });
}

export function renderClosed(canteenName: string): string {
  return render(closedTemplate, { canteenName: linkUniversityMentions(canteenName) });
}

export function renderPrivacy(): string {
  return render(privacyTemplate, {});
}

export function renderError(requestId?: string): string {
  return render(errorTemplate, {
    requestId: requestId ? render(requestIdTemplate, { requestId }) : "",
  });
}

function priceRow(label: string, amount: string): string {
  return render(priceRowTemplate, { label, amount });
}
