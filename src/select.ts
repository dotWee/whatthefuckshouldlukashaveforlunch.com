import { MensaClosedError, type MenuItem } from "./types.ts";

export function selectRandomItem(menuItems: readonly MenuItem[]): MenuItem {
  if (menuItems.length === 0) {
    throw new MensaClosedError("The canteen has no meals for today.");
  }

  return menuItems[randomIndex(menuItems.length)] as MenuItem;
}

function randomIndex(count: number): number {
  const limit = Math.floor(0x1_0000_0000 / count) * count;
  const buffer = new Uint32Array(1);

  do {
    crypto.getRandomValues(buffer);
  } while ((buffer[0] ?? 0) >= limit);

  return (buffer[0] ?? 0) % count;
}
