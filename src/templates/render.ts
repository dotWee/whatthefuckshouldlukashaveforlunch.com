export function escapeHtml(value: string): string {
  return value
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#39;");
}

export function render(template: string, values: Record<string, string>): string {
  return template
    .replaceAll(/\{\{\{\s*([a-zA-Z0-9_]+)\s*\}\}\}/g, (_, key: string) => values[key] ?? "")
    .replaceAll(/\{\{\s*([a-zA-Z0-9_]+)\s*\}\}/g, (_, key: string) => escapeHtml(values[key] ?? ""));
}
